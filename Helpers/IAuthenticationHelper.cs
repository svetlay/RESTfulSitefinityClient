using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Net;

namespace SFWinformsClient.Helpers
{
    public interface IAuthenticationHelper
    {

        #region Methods

        bool SignIn(string username, string password, string url);

        void SetCredentials(string username, string password);

        bool SignOut();

        void CallService(string serviceUrl, byte[] inputData, string httpMethod, out string responseBody, string contentType="");

        HttpStatusCode Request(string url, out string responseBody, out WebHeaderCollection responseHeaders, byte[] data = null, string httpMethod = "GET", string contentType = "application/json", NameValueCollection requestHeaders = null);

        #endregion
        
        
    }
}
