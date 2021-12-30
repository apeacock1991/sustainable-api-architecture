using System;
namespace sustainable_api_architecture.Models
{
    public interface IWeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureCelcius { get; set; }

        public double temperatureFarenheit();
        public string Summary();
    }
}