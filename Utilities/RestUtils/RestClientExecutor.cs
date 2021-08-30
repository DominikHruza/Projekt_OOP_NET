using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.RestUtils
{
    public static class RestClientExecutor
    {
        public static IRestResponse<T> GetResponse<T>(string url)
        {
            var apiClient = new RestClient(url);
            apiClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            return apiClient.Execute<T>(new RestRequest());
        }
    }
}
