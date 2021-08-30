using DAL.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.EndpointUtils;

namespace DAL.Models.Endpoints
{
    class WorldCupWomen2019Endpoint : IWorldCupEndpoint
    {  
        public string MatchesURL()
        {
            IURLBuilder urlBuilder = new URLBuilder();
            urlBuilder.SetBaseURL("https://worldcup.sfg.io");
            urlBuilder.SetParam("/matches");
            return urlBuilder.GetURL();
        }

        public string TeamResultsURL()
        {
            IURLBuilder urlBuilder = new URLBuilder();
            urlBuilder.SetBaseURL("https://worldcup.sfg.io");
            urlBuilder.SetParam("/teams");
            urlBuilder.SetParam("/results");
            return urlBuilder.GetURL();
        }

        public string CountryFilteredMatchesURL(string fifaCountryCode)
        {
            IURLBuilder urlBuilder = new URLBuilder();
            urlBuilder.SetBaseURL("https://worldcup.sfg.io");
            urlBuilder.SetParam("/matches");
            urlBuilder.SetParam("/country?");
            urlBuilder.SetParam($"fifa_code={fifaCountryCode}");
            return urlBuilder.GetURL();
        }      
    }
}
