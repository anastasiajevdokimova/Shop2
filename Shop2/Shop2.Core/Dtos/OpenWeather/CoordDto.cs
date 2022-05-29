using Newtonsoft.Json;

namespace Shop2.Core.Dtos.OpenWeather
{
    public class CoordDto
    {
        [JsonProperty("name")]
        public string name {get;set;}
    }
}