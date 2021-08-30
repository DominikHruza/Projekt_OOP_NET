using Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Models
{
    public class MatchPlayer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        public override bool Equals(object obj)
        {
            return obj is MatchPlayer player &&
                   Name == player.Name;
        }

        public MatchPlayer() { }

        public MatchPlayer(string name, bool captain, long shirtNumber, string position)
        {
            Name = name;
            Captain = captain;
            ShirtNumber = shirtNumber;
            Position = position;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public string ParseToFileLine()
        {
            return $"{Name}|{Captain}|{ShirtNumber}|{Position}";
        }

        public static MatchPlayer ParseFromFileLine(string line)
        {
            string[] props = line.Split(AppConstants.DELIMITER);
            return new MatchPlayer(
                props[0],
                bool.Parse(props[1]),
                long.Parse(props[2]),
                props[3]
            );
        }
    }
}
