using DAL.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Protocols
{
    public interface IWorldCupRepository
    {
        List<MatchData> GetAllMatches();
        List<Team> GetAllTeams();
        List<MatchData> GetMatchByCountryCode(string code);
    }
}
