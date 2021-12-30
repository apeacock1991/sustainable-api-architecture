using System;
using System.Collections.Generic;
using System.Text.Json;
using sustainable_api_architecture.Repositories;

namespace sustainable_api_architecture.Infrastructure
{
	public class ForecastFileReader : Repositories.IDataReader
	{

		// A simple file reader, the key part is the fact we don't return
		// the RawForecastData - this would break the dependency rules we laid out
		// as the Repository layer would then need to know about the raw data
		// format from this layer.
		// Instead, we return ForeCast data, which is a concrete implementation of
		// the IForecastData interface that's defined in the Repository layer.
		// This means the repository remains unaware of the raw data format, protecting
		// it from things like file format changes, or field name changes (or even the
		// type of data / where it's being loaded from)
		public IEnumerable<IForecastData> GetData()
        {
			string fileName = "Data/weather.json";
			string jsonString = System.IO.File.ReadAllText(fileName);

			var raw_data = JsonSerializer.Deserialize<IEnumerable<RawForecastData>>(jsonString);
			var forecast_data = new List<IForecastData>();

			foreach (var i in raw_data)
            {
				forecast_data.Add(
					new ForecastData
                    {
						Date = i.date,
						TemperatureCelcius = i.temperatureC
                    }
				);
			}

			return forecast_data;
		}
	}
}

