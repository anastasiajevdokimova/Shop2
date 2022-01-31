using RestSharp;
using Shop2.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.ApplicationServices.Services
{
    public class WeatherForecastServices
    {
        public async Task<WeatherDto>WeatherResponse()
        {
            string idWeather = "YjhxFOy76ijmCOWvahkPo2Z9lqpk9ot4"; //APi key
            var client = new RestClient($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/");
            var client2 = new RestClient($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=YjhxFOy76ijmCOWvahkPo2Z9lqpk9ot4&language=en-us&details=false&metric=true");


            return null;
        }

        

    }
}
