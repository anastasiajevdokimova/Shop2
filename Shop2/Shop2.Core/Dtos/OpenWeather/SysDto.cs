using Newtonsoft.Json;
using System;

namespace Shop2.Core.Dtos.OpenWeather
{
    public class SysDto
    {
        [JsonProperty("type")]
        public int type { get; set; }
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("message")]
        public float message { get; set; }
        [JsonProperty("country")]
        public string country { get; set; }
        [JsonProperty("sunrise")]
        public Int64 sunrise { get; set; }
        [JsonProperty("sunset")]
        public Int64 sunset { get; set; }
    }

}