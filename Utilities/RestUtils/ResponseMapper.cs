using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.RestUtils
{
    public static class ResponseMapper
    {
        public static T ConvertFromJSON<T>(string jsonResult )
        {
            return JsonConvert.DeserializeObject<T>(
               jsonResult,
               new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }
               );
        }
            
    }
}
