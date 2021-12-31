using System;

// Layer: Repository & Adapter
namespace sustainable_api_architecture.Repositories
{

    // We define the interface here, and it's implemented in the ForecastData class
    // in the Infrastructure layer. We do this so that we invert the dependency, so that
    // the repo knows nothing of the infrastructure layer
    public interface IForecastData
    {
        public DateTime Date { get; set; }
        public int TemperatureCelcius { get; set; }
    }
}

