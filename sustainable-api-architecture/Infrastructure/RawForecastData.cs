using System;

namespace sustainable_api_architecture.Infrastructure
{

	// This class must match the format in the JSON file, and is used to
	// deserialize the JSON
	public class RawForecastData
	{
		public DateTimeOffset date { get; set; }
		public int temperatureC { get; set; }
	}
}

