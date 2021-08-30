using System;
using DAL.Protocols;

namespace DAL.Factories
{
    static class WorldCupEndpointFactory
    {
        public static IWorldCupEndpoint GetEndpoint(string endpointName)
        {
            Type type = Type.GetType(endpointName);
            return Activator.CreateInstance(type) as IWorldCupEndpoint;
        }
    }
}
