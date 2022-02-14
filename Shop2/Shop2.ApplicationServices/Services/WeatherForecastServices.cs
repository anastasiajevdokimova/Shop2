using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        WeatherResultDto IWeatherForecastServices.GetResponse(string city)
        {
            string idWeather = "YjhxFOy76ijmCOWvahkPo2Z9lqpk9ot4"; //APi key
            var Location = "127964";
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{Location}?apikey=YjhxFOy76ijmCOWvahkPo2Z9lqpk9ot4&language=en-us&details=false&metric=true";
            var url2 = new RestClient($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=YjhxFOy76ijmCOWvahkPo2Z9lqpk9ot4&language=en-us&details=false&metric=true");

            var request = new RestRequest(Method.GET);
            IRestResponse response = url2.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                return content.ToObject<WeatherResultDto>();
            }
            //using (WebClient client = new WebClient())
            //{
            //    string json = client.DownloadString(url);

            //    DailyForecastDto weatherInfo = (new JavaScriptSerializer()).Deserialize<DailyForecastDto>(json);
            //    HeadlineDto headlineInfo = (new JavaScriptSerializer()).Deserialize<HeadlineDto>(json);

            //    WeatherResultDto result = new WeatherResultDto();

            //    //Headline
            //    result.EffectiveDate = headlineInfo.EffectiveDate;
            //    result.EffectiveEpochDate = headlineInfo.EffectiveEpochDate;
            //    result.Severity = headlineInfo.Severity;
            //    result.Text = headlineInfo.Text;
            //    result.Category = headlineInfo.Category;
            //    result.EndDate = headlineInfo.EndDate;
            //    result.EndEpochDate = headlineInfo.EndEpochDate;
            //    result.MobileLink = headlineInfo.MobileLink;
            //    result.Link = headlineInfo.Link;
            //    //DailyForecasts
            //    result.Date = weatherInfo.Date;
            //    result.EpochDate = weatherInfo.EpochDate;
            //    //Temperature:
            //    //Minimum
            //    MinimumDto minimumDto = new MinimumDto();
            //    result.TempMinValue = minimumDto.Value;
            //    result.TempMinUnit = minimumDto.Unit;
            //    result.TempMinUnitType = minimumDto.UnitType;
            //    //Maximum
            //    MaximumDto maximumDto = new MaximumDto();
            //    result.TempMaxValue = maximumDto.Value;
            //    result.TempMaxUnit = maximumDto.Unit;
            //    result.TempMaxUnitType = maximumDto.UnitType;
            //    //Day
            //    DayDto dayDto = new DayDto();
            //    result.DayIcon = dayDto.Icon;
            //    result.DayIconPhrase = dayDto.IconPhrase;
            //    result.DayHasPrecipitation = dayDto.HasPrecipitation;
            //    result.DayPrecipitationType = dayDto.PrecipitationType;
            //    result.DayPrecipitationIntensity = dayDto.PrecipitationIntensity;
            //    //Night
            //    NightDto nightDto = new NightDto();
            //    result.NightIcon = nightDto.Icon;
            //    result.NightIconPhrase = nightDto.IconPhrase;
            //    result.NightHasPrecipitation = nightDto.HasPrecipitation;
            //    result.NightPrecipitationType = nightDto.PrecipitationType;
            //    result.NightPrecipitationIntensity = nightDto.PrecipitationIntensity;

            //    var jsonString = new JavaScriptSerializer().Serialize(result);

            //    return jsonString;

            //}
            return null;
        }

        

    }
}
