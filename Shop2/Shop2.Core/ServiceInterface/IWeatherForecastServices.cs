using Shop2.Core.Dtos.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Core.ServiceInterface
{
    public interface IWeatherForecastServices
    {
        //string WeatherResponse(string city);
        Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
        
    }
}