using System;
using System.Collections.Generic;
using sustainable_api_architecture.Models;

// Layer: Application
namespace sustainable_api_architecture.Services
{
    // In a real-world application, you probably have multiple repositories so
    // you'd want a base IRepository class that implements generic methods
    // (e.g. Read, Find etc.) and then extend that generic interface and apply
    // specifics to each different repo you need.
    // https://medium.com/@pererikbergman/repository-design-pattern-e28c0f3e4a30 has
    // a sensible guide
    public interface IAllForecasts
    {
        public IEnumerable<IWeatherForecast> GetForecast();
    }
}

