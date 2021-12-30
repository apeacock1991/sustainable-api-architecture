using System;
namespace sustainable_api_architecture.Models
{

    // Our only domain entity, super simple but it demonstrates the architecture well
    // The main thing to look for is that there are no dependencies.
    public class WeatherForecast : IWeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureCelcius { get; set; }

        public double temperatureFarenheit()
        {
            return 32 + (TemperatureCelcius * 1.8);
        }

        // You'll want to use an enum for this in the real-world
        public string Summary()
        {
            if (TemperatureCelcius < 10)
            {
                return "Cold";
            }
            else if (TemperatureCelcius < 20)
            {
                return "Warm";
            }
            else
            {
                return "Hot";
            }
        }
    }
}

