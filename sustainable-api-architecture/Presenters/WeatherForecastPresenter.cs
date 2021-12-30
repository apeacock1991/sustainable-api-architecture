using System;
using sustainable_api_architecture.Models;

namespace sustainable_api_architecture.Presenters
{
	// A simple presenter that lives in the API layer for translating
	// the domain entities into the format used for the response from the API
	public class WeatherForecastPresenter
	{
		public DateTimeOffset Date { get; set; }
		public int TemperatureInCelcius { get; set; }
		public double TemperatureInFarenheit { get; set; }
		public string WeatherDescription { get; set; }

		public WeatherForecastPresenter(IWeatherForecast weatherForecast)
		{
			Date = weatherForecast.Date;
			TemperatureInCelcius = weatherForecast.TemperatureCelcius;
			TemperatureInFarenheit = weatherForecast.temperatureFarenheit();
			WeatherDescription = weatherForecast.Summary();
		}
	}
}

