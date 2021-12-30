using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using sustainable_api_architecture.Infrastructure;
using sustainable_api_architecture.Models;
using sustainable_api_architecture.Repositories;

namespace sustainable_api_architecture_tests.Repositories
{
    public class ForecastRepositoryTests
    {
        [Test]
        public void TestRepositoryTranslation()
        {
            var repository = new ForecastRepository(new FakeDataReader());
            var forecasts = repository.GetForecast();


            Assert.That(forecasts.Count() == 2);
            Assert.That(forecasts.All(f => f is WeatherForecast));
        }
    }

    // There are frameworks to help create stubs, but for simplicity
    // i've just written my own fake class. It still demonstrates the point,
    // I'm able to test the repo in total isolation.
    public class FakeDataReader : IDataReader
    {
        public IEnumerable<IForecastData> GetData()
        {
            var fake_data = new List<IForecastData>();

            // We shouldn't use this concrete class from the Infrastructure layer
            // really, but the fake library would handle this for us for a real app
            fake_data.Add(
                new ForecastData
                {
                    Date = new DateTime(2021, 12, 25),
                    TemperatureCelcius = 5
                }
            );
            fake_data.Add(
                new ForecastData
                {
                    Date = new DateTime(2021, 12, 26),
                    TemperatureCelcius = 13
                }
            );

            return fake_data;
        }
    }
}
