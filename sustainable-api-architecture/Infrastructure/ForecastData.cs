using System;
using sustainable_api_architecture.Repositories;

// Layer: Infrastructure
namespace sustainable_api_architecture.Infrastructure
{
    public class ForecastData : IForecastData
    {
        public DateTime Date { get; set; }
        public int TemperatureCelcius { get; set; }
    }
}

