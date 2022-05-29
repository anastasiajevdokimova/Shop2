using Newtonsoft.Json;
using Shop2.Core.Dtos.OpenWeathers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Core.Dtos.OpenWeather
{
    public class OpenWeatherDto
    {
        public CoordDto coord { get; set; }
        public List<OWeatherDto> weather { get; set; }
        [JsonProperty("base")]
        //public string @base {get;set;}
        public MainDto main { get; set; }
        [JsonProperty("visibility")]
        public Int64 visibility { get; set; }
        public WindDto wind { get; set; }
        public CloudsDto clouds { get; set; }
        [JsonProperty("dt")]
        public Int64 dt { get; set; }
        public SysDto sys { get; set; }
        [JsonProperty("timezone")]
        public Int64 timezone { get; set; }
        [JsonProperty("id")]
        public Int64 id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("cod")]
        public int cod { get; set; }

    }
}
