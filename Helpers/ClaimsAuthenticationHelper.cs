using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.Collections.Specialized;
using System.IO;
using System.Diagnostics;

namespace SFWinformsClient.Helpers
{
    class ClaimsAuthenticationHelper : IAuthenticationHelper
    {

               

        #region Authentication Handling

        public bool SignOut()
        {
            string responseBody;
            WebHeaderCollection responseHeaders;
            var requestHeaders = new NameValueCollection();
            requestHeaders["Authorization"] = String.Format("WRAP access_token=\"{0}\"", bootstrapToken);
            var responseCode = Request(baseUrl + "Sitefinity/SignOut", out responseBody, out responseHeaders, requestHeaders: requestHeaders);
            if (responseCode != HttpStatusCode.OK)
            {
                // Something went wrong
                return false;
            }
            return true;
        }

        public bool SignIn(string username, string password, string url)
        {

            string result;
           
            this.SetCredentials(username, password);
            this.baseUrl = url;
            result = this.SetSecurityToken();

            if (result == "wrong")
                return false;

            return true;

        }

        /// <summary>
        /// Gets the security token.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <returns></returns>
        public string SetSecurityToken()
        {
            
            // we first have to determine the configured authentication method
            var authUrl = baseUrl + "Sitefinity/Authenticate";
            string response;
            WebHeaderCollection headers;
            var statusCode = Request(authUrl, out response, out headers);
            switch (statusCode)
            {
                case HttpStatusCode.OK:
                    // This means the STS (Security Token Service) is in the same site and we can submit the credentials directly.
                    // In this example we are going to use WRAP with Simple Web Token, therefore we need to add 
                    // /SWT to the service URL 
                    var formData = String.Format("wrap_name={0}&wrap_password={1}", username, password);
                    var bytes = Encoding.UTF8.GetBytes(formData);
                    var responseCode = Request(authUrl + "/SWT", out response, out headers, bytes, "POST", "application/x-www-form-urlencoded");
                    
                    if (responseCode == HttpStatusCode.OK)
                    {
                        // we expect WRAP formatted response which is the same as query string
                        var nameValueColl = HttpUtility.ParseQueryString(response);
                        bootstrapToken = nameValueColl["wrap_access_token"];
                        expiresOn = DateTime.Now + TimeSpan.FromSeconds(int.Parse(nameValueColl["wrap_access_token_expires_in"]));
                        return "set";
                    }
                    if (responseCode == HttpStatusCode.Unauthorized)
                    {
                        // This means wrong credentials were submitted

                        return "wrong";
                    }
                    // Unexpected response
                    goto default;
                case HttpStatusCode.Redirect:
                    // This means the site is using external STS or Single Sign-on
                    // You have to obtain the token form the STS specified in the location parameter in the response headers
                    return "set";
                default:
                    return "quit";
            }
        }



        public void SetCredentials(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        #endregion

        #region Service calls
        public void CallService(string serviceUrl, byte[] inputData, string httpMethod, out string responseBody, string contentType = "")
        {

            string sitefinityHost = baseUrl;
            string url = sitefinityHost + serviceUrl;
            WebHeaderCollection responseHeaders;
            

            // NOTE: in this example we are going to add the bootstrap security token with every request, however bootstrap security tokens require
            // a bit more processing on the server then session security tokens. When you make a request providing a bootstrap token, 
            // Sitefinity will add session token in the response cookies collection. Cookies with FedAuth in the name comprise the session token.
            var requestHeaders = new NameValueCollection();
            requestHeaders["Authorization"] = String.Format("WRAP access_token=\"{0}\"", bootstrapToken);

            // We could check if the token is close to expire and we can renew it in advance or alternatively we could catch the error response.
            // In general the first approach is more efficient but for the sake of demoing we will use the second one.    
            var responseCode = Request(url, out responseBody, out responseHeaders, inputData, httpMethod, "application/json", requestHeaders);
            switch (responseCode)
            {
                case HttpStatusCode.OK:
                    //Console.WriteLine("Created successfully.");
                    break;
                case HttpStatusCode.Unauthorized:
                    if (responseHeaders["X-Authentication-Error"] == "TokenExpired")
                    {
                        SetSecurityToken();
                
                    }
                    goto default;
                case HttpStatusCode.Forbidden:
                    if (responseHeaders["X-Authentication-Error"] == "UserAlreadyLoggedIn")
                    {
                        Debug.WriteLine("Someone is already using this username and password from another computer or browser. To proceed, you need to log him/her off.");
                        
                    }
                    goto default;
                default:
                    
                    break;
            }

        }



        public HttpStatusCode Request(string url, out string responseBody, out WebHeaderCollection responseHeaders, byte[] data = null, string httpMethod = "GET", string contentType = "", NameValueCollection requestHeaders = null)
        {
            // Create and set the request object
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = httpMethod;
            request.ContentType = contentType;
            request.CookieContainer = new CookieContainer();
            if (requestHeaders != null)
                request.Headers.Add(requestHeaders);

            request.KeepAlive = true;
            //if(contentType == "application/json")
            //    request.Headers.Add("Content-Type", contentType);

            // Add cookies if there are any
            if (cookies != null)
            {
                foreach (Cookie cookie in cookies)
                    if (!cookie.Expired)
                        request.CookieContainer.Add(cookie);
            }

            if (data != null)
            {
                request.ContentLength = data.Length;
                // Send the data to the request stream
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(data, 0, data.Length);
                }
            }

            // Invoke the method and return the response.
            HttpStatusCode statusCode;
            HttpWebResponse response = null;
        
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    response = (HttpWebResponse)ex.Response;
                }
            }
            finally
            {
                if (response != null)
                {
                    // Store the cookies from the response for the current session.
                    cookies = response.Cookies;

                    // Read the response
                    using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                    responseHeaders = response.Headers;
                    statusCode = response.StatusCode;
                    response.Close();
                }
                else
                {
                    statusCode = HttpStatusCode.InternalServerError;
                    responseBody = "";
                    responseHeaders = null;
                }
            }
            //SignOut();
            return statusCode;
        }

        #endregion

        #region Properties

        // Here we will store the cookies for the current session. 
        // If the application needs to support cookies across sessions then you have to store the collection
        protected CookieCollection cookies;

        protected string baseUrl;
        protected string username;
        protected string password;
        protected string bootstrapToken;
        protected DateTime expiresOn;

        #endregion





       
    }
}
