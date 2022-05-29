using Newtonsoft.Json;

namespace Shop2.Core.Dtos.OpenWeather
{
    public class CloudsDto
    {
        [JsonProperty("all")]
        public int all { get; set; }
    }
}