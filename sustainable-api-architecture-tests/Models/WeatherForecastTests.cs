using System;
using NUnit.Framework;
using sustainable_api_architecture.Models;

namespace sustainable_api_architecture_tests.Models
{
    public class WeatherForecastTests
    {
        [Test]
        public void TestFarenheitCalculation()
        {
            var forecast = new WeatherForecast
            {
                Date = new DateTime(2021, 12, 30),
                TemperatureCelcius = 10
            };

            Assert.That(forecast.temperatureFarenheit() == 50);
        }

        [Test]
        public void TestSummaryCold()
        {
            var forecast = new WeatherForecast
            {
                Date = new DateTime(2021, 12, 30),
                TemperatureCelcius = 5
            };

            Assert.That(forecast.Summary() == "Cold");
        }

        [Test]
        public void TestSummaryWarm()
        {
            var forecast = new WeatherForecast
            {
                Date = new DateTime(2021, 12, 30),
                TemperatureCelcius = 17
            };

            Assert.That(forecast.Summary() == "Warm");
        }

        [Test]
        public void TestSummaryHot()
        {
            var forecast = new WeatherForecast
            {
                Date = new DateTime(2021, 12, 30),
                TemperatureCelcius = 26
            };

            Assert.That(forecast.Summary() == "Hot");
        }
    }
}
