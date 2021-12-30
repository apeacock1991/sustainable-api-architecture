using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using sustainable_api_architecture.Presenters;
using sustainable_api_architecture.Services;

namespace sustainable_api_architecture.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IRetrieveForecast _retrieveForecast;

        public WeatherForecastController(IRetrieveForecast retrieveForecast)
        {
            _retrieveForecast = retrieveForecast;
        }

        [HttpGet]
        public IEnumerable<WeatherForecastPresenter> Get(int days)
        {
            var all_forecasts = _retrieveForecast.Call(days);

            var response = new List<WeatherForecastPresenter>();

            foreach (var forecast in all_forecasts)
            {
                response.Add(
                    new WeatherForecastPresenter(forecast)
                );
            }

            return response;
        }
    }
}

