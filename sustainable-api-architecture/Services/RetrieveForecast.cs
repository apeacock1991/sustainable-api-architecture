using System;
using System.Collections.Generic;
using System.Linq;
using sustainable_api_architecture.Models;

// Layer: Application
namespace sustainable_api_architecture.Services
{
    public class RetrieveForecast : IRetrieveForecast
    {
        private readonly IAllForecasts _allForecasts;

        public RetrieveForecast(IAllForecasts allForecasts)
        {
            _allForecasts = allForecasts;
        }

        public IEnumerable<IWeatherForecast> Call(int days)
        {
            var forecast = _allForecasts.GetForecast();

            if (days > forecast.Count())
            {
                throw new ArgumentException("You requested more days than are available");

            }

            // By the letter of the law, we shouldn't return the domain entities here as
            // we're passing the data through several layers. However, considering the size
            // of the application, it's not worth it at this point and would just look odd
            // considering we'd just be mapping into a similar data format and returning that

            // As your service grows, you can look for these pain points between layers and
            // introduce abstractions where they are needed. Keep an eye out for anemic layers
            // though, where nothing is happening and data is just passed around.
            return forecast.Take(days);
        }
    }
}

