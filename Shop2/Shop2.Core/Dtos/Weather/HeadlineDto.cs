﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop2.Models.Core.Dtos.Weather
{
    public class HeadlineDto
    {
        [JsonProperty ("EffectiveDate")]
        public string EffectiveDate { get; set; }
        [JsonProperty("EffectiveEpochDate")]
        public Int64 EffectiveEpochDate { get; set; }
        [JsonProperty("Severity")]
        public int Severity { get; set; }
        [JsonProperty("Text")]
        public string Text { get; set; }
        [JsonProperty("Category")]
        public string Category { get; set; }
        [JsonProperty("EndDate")]
        public string EndDate { get; set; }
        [JsonProperty("EndEpochDate")]
        public Int64 EndEpochDate { get; set; }
        [JsonProperty("MobileLink")]
        public string MobileLink { get; set; }
        [JsonProperty("Link")]
        public string Link { get; set; }
    }
}
