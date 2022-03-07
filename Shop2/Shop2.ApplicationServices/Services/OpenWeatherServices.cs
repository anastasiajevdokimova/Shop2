using Nancy.Json;
using Shop2.Core.Dtos.OpenWeather;
using Shop2.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.ApplicationServices.Services
{
    public class OpenWeatherServices : IOpenWeatherServices
    {
        public async Task<OpenWeatherResultDto> WeatherDetail(OpenWeatherResultDto dto)
        {
            string apikey = "d7e4c8388840f164d4bd9f7804aec898";

            //var CityName = $"http://api.openweathermap.org/geo/1.0/direct?q=London&limit=5&appid={apikey}";
           // var url = $"http://api.openweathermap.org/data/2.5/weather?q=Tallinn&limit=5&units=metric&appid={apikey}";
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={dto.name}&limit=5&units=metric&appid={apikey}";
           
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                OpenWeatherDto weatherInfo = new JavaScriptSerializer().Deserialize<OpenWeatherDto>(json);

                dto.name = weatherInfo.name;
                dto.main = weatherInfo.weather[0].main;
                dto.description = weatherInfo.weather[0].description;
                dto.icon = weatherInfo.weather[0].icon;

                dto.temp = weatherInfo.main.temp;
                dto.feels_like = weatherInfo.main.feels_like;
                dto.temp_min = weatherInfo.main.temp_min;
                dto.temp_max = weatherInfo.main.temp_max;
                dto.pressure = weatherInfo.main.pressure;
                dto.humidity = weatherInfo.main.humidity;
                dto.visibility = weatherInfo.visibility;

                dto.speed = weatherInfo.wind.speed;
                dto.deg = weatherInfo.wind.deg;

                dto.all = weatherInfo.clouds.all;

                dto.dt = weatherInfo.dt;

                dto.type = weatherInfo.sys.type;
                dto.id = weatherInfo.sys.id;
                dto.message = weatherInfo.sys.message;
                dto.country = weatherInfo.sys.country;
                dto.sunrise = weatherInfo.sys.sunrise;
                dto.sunset = weatherInfo.sys.sunset;
                dto.timezone = weatherInfo.timezone;

                var jsonString = new JavaScriptSerializer().Serialize(dto);
            }
            return dto;
        } 
    }
}
