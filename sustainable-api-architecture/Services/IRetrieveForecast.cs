using System;
using System.Collections.Generic;
using sustainable_api_architecture.Models;

// Layer: Application
namespace sustainable_api_architecture.Services
{
    public interface IRetrieveForecast
    {
        public IEnumerable<IWeatherForecast> Call(int days);
    }
}

