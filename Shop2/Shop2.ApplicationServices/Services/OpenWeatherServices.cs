using Shop2.Core.Dtos.OpenWeather;
using Shop2.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.ApplicationServices.Services
{
    public class OpenWeatherServices : IOpenWeatherServices
    {
        public async Task<OpenWeatherResultDto> WeatherDetail(OpenWeatherResultDto dto)
        {
            string apikey = "d7e4c8388840f164d4bd9f7804aec898";
            var url = $"http://api.openweathermap.org/data/2.5/weather?q=London&limit=5&appid={apikey}";


            return dto;
        } 
    }
}
