using DAL.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Endpoints;
using DAL.Repos;
using Utilities.OptionUtils;

namespace DAL.Factories
{
    public static class WorldCupRepoFactory
    {
        public static IWorldCupRepository GetRepository(ContestType option)
        {
            return WorldCupRepoSingleton
                .GetInstance()
                .SetRepo(option)
                .GetCurrentRepository();
        }
    }
}
