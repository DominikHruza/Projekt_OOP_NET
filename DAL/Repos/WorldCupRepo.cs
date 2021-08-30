
using DAL.Factories;
using DAL.Protocols;
using Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using Utilities.RestUtils;


namespace DAL.Repos
{
    class WorldCupRepo : IWorldCupRepository
    {
        private IWorldCupEndpoint worldCupEndpoint;

        private WorldCupRepo()
        {}

        public WorldCupRepo(Type endpointType)
        {
            this.worldCupEndpoint = WorldCupEndpointFactory.GetEndpoint(
             endpointType.FullName);
        }

        public List<MatchData> GetAllMatches()
        {
            var restResponse = RestClientExecutor.GetResponse<List<MatchData>>(
                worldCupEndpoint.MatchesURL());

            return ResponseMapper.ConvertFromJSON<List<MatchData>>(restResponse.Content);
        }

        public List<Team> GetAllTeams()
        {
            var restResponse = RestClientExecutor.GetResponse<List<Team>>(
                worldCupEndpoint.TeamResultsURL());

            return ResponseMapper.ConvertFromJSON<List<Team>>(restResponse.Content);
        }

        public List<MatchData> GetMatchByCountryCode(string code)
        {           
            var restResponse = RestClientExecutor.GetResponse<MatchData>(
               worldCupEndpoint.CountryFilteredMatchesURL(code));

            return ResponseMapper.ConvertFromJSON<List<MatchData>>(restResponse.Content);
        }

    }
}

