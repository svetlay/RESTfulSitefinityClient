using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;

namespace SFWinformsClient.Helpers
{
    class FormsAuthenticationHelper : IAuthenticationHelper
    {

        #region Authentication
        public bool SignIn(string username, string password, string url)
        {

            this.SetCredentials(username, password);
            this.baseUrl = url;


            string json = String.Format(credentialsFormat, String.Empty, password, "true", username);
            byte[] credentials = Encoding.UTF8.GetBytes(json);
            string responseBody;

            CallService(authServiceUrl + "Authenticate", credentials,  "POST", out responseBody, "application/json");
            Debug.WriteLine(responseBody);

            return true;
        }

        public void SetCredentials(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public bool SignOut()
        {
            string responseBody;
            WebHeaderCollection responseHeaders;
            string url = String.Concat(baseUrl,authServiceUrl, "Logout");
            
            var responseCode = Request(url, out responseBody, out responseHeaders, null);
            if (responseCode != HttpStatusCode.OK)
            {
                // Something went wrong
                return false;
            }
            return true;
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


            // We could check if the token is close to expire and we can renew it in advance or alternatively we could catch the error response.
            // In general the first approach is more efficient but for the sake of demoing we will use the second one.    
            var responseCode = Request(url, out responseBody, out responseHeaders, inputData, httpMethod, contentType, null);

            if (responseCode == HttpStatusCode.OK)
            {
                
                Debug.WriteLine("Call to " + url + " went ok");

            }
            else
                Debug.WriteLine("Call to " + url + " shall not pass");

        }




        public HttpStatusCode Request(string url, out string responseBody, out WebHeaderCollection responseHeaders, byte[] data = null, string httpMethod = "GET", string contentType = "", System.Collections.Specialized.NameValueCollection requestHeaders = null)
        {
            // Create and set the request object
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = httpMethod;
          
            request.ContentType = contentType;
            request.CookieContainer = new CookieContainer();
            if (requestHeaders != null)
                request.Headers.Add(requestHeaders);
    

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
                SignOut();
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

        const string credentialsFormat = @"
                {{
                    ""MembershipProvider"":""{0}"",
                    ""Password"":""{1}"",
                    ""Persistent"":{2},
                    ""UserName"":""{3}""
                }}";


        private readonly string authServiceUrl = "Sitefinity/Services/Security/Users.svc/";

        #endregion



    }
}
