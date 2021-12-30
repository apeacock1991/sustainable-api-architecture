using System.Collections.Generic;
using sustainable_api_architecture.Models;
using sustainable_api_architecture.Services;

namespace sustainable_api_architecture.Repositories
{
    public class ForecastRepository : IAllForecasts
    {

        private readonly IDataReader _dataReader;

        public ForecastRepository(IDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        // Here, we are leveraging the repository pattern. We are retrieving data
        // from an external source (whether it be a DB, AWS service, local database etc.)
        // and translating that data into domain entities.

        // In this example, I've used a file to keep things simple (you can see that in the
        // ForecastFileReader class. Note however, that this class has no idea where the data
        // is coming from - it just knows it's given an interface that allows it to read
        // data from some source. We could inject a SQL data reader as another option.

        // This becomes particularly useful when unit testing, as we can inject a stub
        // and not worry about the underlying data source.

        // Furthermore, in this example, the format of the file could change,
        // and none of the code would be affected, except the code in the Infrastructure
        // layer.
        public IEnumerable<IWeatherForecast> GetForecast()
        {

            IEnumerable<IForecastData> fileForecasts =
                _dataReader.GetData();

            var weatherForecasts = new List<Models.WeatherForecast>();

            foreach (var forecast in fileForecasts)
            {
                weatherForecasts.Add(
                    new Models.WeatherForecast
                    {
                        Date = forecast.Date,
                        TemperatureCelcius = forecast.TemperatureCelcius
                    }
                );
            }

            return weatherForecasts;
        }
    }
}

