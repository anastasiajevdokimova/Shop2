using Shop2.Core.Dtos.OpenWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Core.ServiceInterface
{
    public interface IOpenWeatherServices
    {
       Task<OpenWeatherResultDto> WeatherDetail(OpenWeatherResultDto dto);
    }
}
