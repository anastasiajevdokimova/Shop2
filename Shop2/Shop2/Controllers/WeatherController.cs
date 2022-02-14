﻿using Microsoft.AspNetCore.Mvc;
using Shop2.Core.Dtos.Weather;
using Shop2.Core.ServiceInterface;
using Shop2.Models.Core.Dtos.Weather;
using Shop2.Models.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop2.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherForecastServices _weatherForecastServices;

        public WeatherController
            (
                IWeatherForecastServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }

        [HttpGet]
        public IActionResult SearchCity()
        {
            SearchCity sc = new SearchCity();

            return View(sc);
        }

        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "Weather", new { city = model.CityName });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
            WeatherResultDto weatherResponse = _weatherForecastServices.GetResponse(city);
            CityViewModel model = new CityViewModel();
            WeatherResultDto dto = new WeatherResultDto();

            if (weatherResponse != null)
            {
                //Headline
                model.EffectiveDate = weatherResponse.EffectiveDate;
                model.EffectiveEpochDate = weatherResponse.EffectiveEpochDate;
                model.Severity = weatherResponse.Severity;
                model.Text = weatherResponse.Text;
                model.Category = weatherResponse.Category;
                model.EndDate = weatherResponse.EndDate;
                model.EndEpochDate = weatherResponse.EndEpochDate;
                model.MobileLink = weatherResponse.MobileLink;
                model.Link = weatherResponse.Link;
                //DailyForecasts
                model.Date = dto.Date;
                model.EpochDate = dto.EpochDate;
                //Temperature:
                //Minimum
                model.TempMinValue = dto.TempMinValue;
                model.TempMinUnit = dto.TempMinUnit;
                model.TempMinUnitType = dto.TempMinUnitType;
                //Maximum
                model.TempMaxValue = dto.TempMaxValue;
                model.TempMaxUnit = dto.TempMaxUnit;
                model.TempMaxUnitType = dto.TempMaxUnitType;
                //Day
                model.DayIcon = dto.DayIcon;
                model.DayIconPhrase = dto.DayIconPhrase;
                model.DayHasPrecipitation = dto.DayHasPrecipitation;
                model.DayPrecipitationType = dto.DayPrecipitationType;
                model.DayPrecipitationIntensity = dto.DayPrecipitationIntensity;
                //Night
                model.NightIcon = dto.NightIcon;
                model.NightIconPhrase = dto.NightIconPhrase;
                model.NightHasPrecipitation = dto.NightHasPrecipitation;
                model.NightPrecipitationType = dto.NightPrecipitationType;
                model.NightPrecipitationIntensity = dto.NightPrecipitationIntensity;
            }

            return View(model);
        }
    }
}
