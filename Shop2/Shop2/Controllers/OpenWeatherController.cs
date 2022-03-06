using Microsoft.AspNetCore.Mvc;
using Shop2.ApplicationServices.Services;
using Shop2.Core.Dtos.OpenWeather;
using Shop2.Core.Dtos.OpenWeathers;
using Shop2.Core.ServiceInterface;
using Shop2.Models.OpenWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop2.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly IOpenWeatherServices _openWeatherServices;
        public OpenWeatherController
            (
                IOpenWeatherServices openWeatherServices
            )
        {
            _openWeatherServices = openWeatherServices;
        }

        [HttpGet]
        public IActionResult OSearchCity()
        {
            OpenSearchCity osc = new OpenSearchCity();

            return View(osc);
        }
        [HttpPost]
        public IActionResult OSearchCity(OpenSearchCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "OpenWeather", new { city = model.CityName });
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult City()
        {

            OpenWeatherResultDto dto = new OpenWeatherResultDto();

            var weatherResponse = _openWeatherServices.WeatherDetail(dto);

            OpenCityViewModel model = new OpenCityViewModel();

            model.name = weatherResponse.Result.name;
            model.main = weatherResponse.Result.main;
            model.description = weatherResponse.Result.description;
            model.icon = weatherResponse.Result.icon;

            model.temp = weatherResponse.Result.temp;
            model.feels_like = weatherResponse.Result.feels_like;
            model.temp_min = weatherResponse.Result.temp_min;
            model.temp_max = weatherResponse.Result.temp_max;
            model.pressure = weatherResponse.Result.pressure;
            model.humidity = weatherResponse.Result.humidity;
            model.visibility = weatherResponse.Result.visibility;

            model.speed = weatherResponse.Result.speed;
            model.deg = weatherResponse.Result.deg;

            model.all = weatherResponse.Result.all;
            model.dt = weatherResponse.Result.dt;
            model.type = weatherResponse.Result.type;
            model.id = weatherResponse.Result.id;
            model.message = weatherResponse.Result.message;
            model.country = weatherResponse.Result.country;
            model.sunrise = weatherResponse.Result.sunrise;
            model.sunset = weatherResponse.Result.sunset;

            model.timezone = weatherResponse.Result.timezone;

            return View(model);
        }
    }
}
