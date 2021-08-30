using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IWorldCupServiceAsync
    {
        Task<List<MatchData>> GetAllMatchesAsync();
        Task<List<Team>> GetAllTeamsAsync();
        Task<List<MatchData>> GetMatchByCountryCodeAsync(string code);
    }
}
