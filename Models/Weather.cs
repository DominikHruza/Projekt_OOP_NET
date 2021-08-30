using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Models
{
    public class Weather
    {
        [JsonProperty("humidity")]
        
        public long Humidity { get; set; }

        [JsonProperty("temp_celsius")]
       
        public long TempCelsius { get; set; }

        [JsonProperty("temp_farenheit")]
       
        public long TempFarenheit { get; set; }

        [JsonProperty("wind_speed")]
      
        public long WindSpeed { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
