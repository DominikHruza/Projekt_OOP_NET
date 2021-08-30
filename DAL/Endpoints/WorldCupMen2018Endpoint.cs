using DAL.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.EndpointUtils;

namespace DAL.Models.Endpoints
{
    class WorldCupMen2018Endpoint : IWorldCupEndpoint
    {
     
        public string MatchesURL()
        {
            IURLBuilder urlBuilder = new URLBuilder();
            urlBuilder.SetBaseURL("https://world-cup-json-2018.herokuapp.com");
            urlBuilder.SetParam("/matches");
            return urlBuilder.GetURL();
        }

        public string TeamResultsURL()
        {
            IURLBuilder urlBuilder = new URLBuilder();
            urlBuilder.SetBaseURL("https://world-cup-json-2018.herokuapp.com");
            urlBuilder.SetParam("/teams");
            urlBuilder.SetParam("/results");
            return urlBuilder.GetURL();
        }

        public string CountryFilteredMatchesURL(string fifaCountryCode)
        {
            IURLBuilder urlBuilder = new URLBuilder();
            urlBuilder.SetBaseURL("https://world-cup-json-2018.herokuapp.com");
            urlBuilder.SetParam("/matches");
            urlBuilder.SetParam("/country?");
            urlBuilder.SetParam($"fifa_code={fifaCountryCode}");
            return urlBuilder.GetURL();
        }
    }
}
