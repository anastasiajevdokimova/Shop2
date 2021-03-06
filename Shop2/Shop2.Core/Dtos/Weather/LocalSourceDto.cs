using Newtonsoft.Json;

namespace Shop2.Models.Core.Dtos.Weather
{
    public class LocalSourceDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("WeatherCode")]
        public string WeatherCode { get; set; }
    }
}