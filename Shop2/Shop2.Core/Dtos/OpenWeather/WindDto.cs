using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Core.Dtos.OpenWeather
{
    public class WindDto
    {
        [JsonProperty("speed")]
        public float speed { get; set; }
        [JsonProperty("deg")]
        public int deg { get; set; }
    }
}
