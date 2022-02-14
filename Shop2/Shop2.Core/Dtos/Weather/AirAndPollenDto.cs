using Newtonsoft.Json;

namespace Shop2.Models.Core.Dtos.Weather
{
    public class AirAndPollenDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Value")]
        public int Value { get; set; }
        [JsonProperty("Category")]
        public string Category { get; set; }
        [JsonProperty("CategoryValue")]
        public int CategoryValue { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
    }
}