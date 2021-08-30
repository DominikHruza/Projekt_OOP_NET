using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.EndpointUtils
{
    public class URLBuilder : IURLBuilder
    {
        private ResourceURL URL;

        public URLBuilder()
        {
            URL = new ResourceURL();     
        }

        public void SetBaseURL(string url)
        {
            URL.BaseURL = url;
           
        }

        public void SetParam(string param)
        {
            URL.Params.Add(param);    
        }
        
        public string GetURL()
        {
            return URL.ToString();
        }
    }
}
