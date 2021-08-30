using DAL.Factories;
using DAL.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.OptionUtils;

namespace DAL.Repos

{
    class WorldCupRepoSingleton
    {
        private IWorldCupRepository worldCupRepository;

        private static WorldCupRepoSingleton _instance;

        private WorldCupRepoSingleton(){}

        public IWorldCupRepository GetCurrentRepository()
        {
            return this.worldCupRepository;
        }

        public WorldCupRepoSingleton SetRepo(ContestType option)
        {
            switch (option)
            {
                case ContestType.WORLDCUP_MEN_2018:
                    this.worldCupRepository =
                         new WorldCupRepo(
                             typeof(Models.Endpoints.WorldCupMen2018Endpoint));
                    break;

                case ContestType.WORLDCUP_WOMEN_2019:
                    this.worldCupRepository =
                         new WorldCupRepo(
                             typeof(Models.Endpoints.WorldCupWomen2019Endpoint));
                    break;
                default:
                    throw new RepoNotFoundException($"Repository {option} not found");

            }

            return _instance;          
        }

        public static WorldCupRepoSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WorldCupRepoSingleton();
            }

            return _instance;
        }
    }
}
