using DAL.Factories;
using DAL.Protocols;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.OptionUtils;

namespace Services
{
    class WorldCupServiceAsync : IWorldCupServiceAsync
    {

       private IWorldCupRepository worldCupRepository;

        private WorldCupServiceAsync() { }

        public WorldCupServiceAsync(ContestType option)
        {
            this.worldCupRepository = WorldCupRepoFactory.GetRepository(option);
        }

        public Task<List<MatchData>> GetAllMatchesAsync()
        {
            return Task.Run(() =>
                worldCupRepository.GetAllMatches()

            );
        }
        
        public Task<List<Team>> GetAllTeamsAsync()
        {
            return Task.Run(() =>
               worldCupRepository.GetAllTeams()
            );
        }

        public Task<List<MatchData>> GetMatchByCountryCodeAsync(string code)
        {
            return Task.Run(() =>
               worldCupRepository.GetMatchByCountryCode(code)
            );
        }
    }
}
