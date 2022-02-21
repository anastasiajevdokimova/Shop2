using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Core.Dtos.OpenWeather
{
    public class MainDto
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public Int64 pressure { get; set; }
        public int humidity { get; set; }
    }
}
