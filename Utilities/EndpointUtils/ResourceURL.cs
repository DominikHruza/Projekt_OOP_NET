using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.EndpointUtils
{
    class ResourceURL
    {
        public string BaseURL { get; set; }
        public ResourceURL() {
            BaseURL = "";
            Params = new List<string>();
        }

        public List<string> Params { get; set; }

        public override string ToString()
        {
            return $"{BaseURL}{String.Join("", Params)}";
        }
    }
}
