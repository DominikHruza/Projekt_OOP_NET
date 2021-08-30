using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Protocols
{
    interface IWorldCupEndpoint
    {
        string MatchesURL();
        string TeamResultsURL();
        string CountryFilteredMatchesURL(string fifaCountryCode);
    }
}
