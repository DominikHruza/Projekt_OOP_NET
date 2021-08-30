using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.EndpointUtils
{
    public interface IURLBuilder
    {
        void SetBaseURL(string url);

        void SetParam(string param);

        string GetURL();
    }
}
