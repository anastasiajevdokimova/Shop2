using Nancy.Json;
using RestSharp;
using Shop2.Core.Dtos;
using Shop2.Core.Dtos.Weather;
using Shop2.Core.ServiceInterface;
using Shop2.Models.Core.Dtos.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public string WeatherResponse(string city)
        {
            string idWeather = "YjhxFOy76ijmCOWvahkPo2Z9lqpk9ot4"; //APi key
            var Location = "127964";
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{Location}?apikey=YjhxFOy76ijmCOWvahkPo2Z9lqpk9ot4&language=en-us&details=false&metric=true";
            //var client2 = new RestClient($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=YjhxFOy76ijmCOWvahkPo2Z9lqpk9ot4&language=en-us&details=false&metric=true");

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                DailyForecastDto weatherInfo = (new JavaScriptSerializer()).Deserialize<DailyForecastDto>(json);
                HeadlineDto headlineInfo = (new JavaScriptSerializer()).Deserialize<HeadlineDto>(json);

                WeatherResultDto result = new WeatherResultDto();

                //Headline
                result.EffectiveDate = headlineInfo.EffectiveDate;
                result.EffectiveEpochDate = headlineInfo.EffectiveEpochDate;
                result.Severity = headlineInfo.Severity;
                result.Text = headlineInfo.Text;
                result.Category = headlineInfo.Category;
                result.EndDate = headlineInfo.EndDate;
                result.EndEpochDate = headlineInfo.EndEpochDate;
                result.MobileLink = headlineInfo.MobileLink;
                result.Link = headlineInfo.Link;
                //DailyForecasts
                result.Date = weatherInfo.Date;
                result.EpochDate = weatherInfo.EpochDate;
                //Temperature:
                //Minimum
                result.TempMinValue = weatherInfo.Temperature.Minimum.Value;
                result.TempMinUnit = weatherInfo.Temperature.Minimum.Unit;
                result.TempMinUnitType = weatherInfo.Temperature.Minimum.UnitType;
                //Maximum
                result.TempMaxValue = weatherInfo.Temperature.Maximum.Value;
                result.TempMaxUnit = weatherInfo.Temperature.Maximum.Unit;
                result.TempMaxUnitType = weatherInfo.Temperature.Maximum.UnitType;
                //Day
                result.DayIcon = weatherInfo.Day.Icon;
                result.DayIconPhrase = weatherInfo.Day.IconPhrase;
                result.DayHasPrecipitation = weatherInfo.Day.HasPrecipitation;
                result.DayPrecipitationType = weatherInfo.Day.PrecipitationType;
                result.DayPrecipitationIntensity = weatherInfo.Day.PrecipitationIntensity;
                //Night
                result.NightIcon = weatherInfo.Night.Icon;
                result.NightIconPhrase = weatherInfo.Night.IconPhrase;
                result.NightHasPrecipitation = weatherInfo.Night.HasPrecipitation;
                result.NightPrecipitationType = weatherInfo.Night.PrecipitationType;
                result.NightPrecipitationIntensity = weatherInfo.Night.PrecipitationIntensity;

                var jsonString = new JavaScriptSerializer().Serialize(result);

                return jsonString;

            }

        }

        

    }
}
