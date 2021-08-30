using DAL.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.OptionUtils;

namespace Services
{
    public static class WorldCupServiceFactory
    {
        public static IWorldCupServiceAsync GetAsyncService(ContestType option)
        {
            return new WorldCupServiceAsync(option);
        }
    }
}
