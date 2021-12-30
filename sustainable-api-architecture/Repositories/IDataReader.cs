using System;
using System.Collections.Generic;

namespace sustainable_api_architecture.Repositories
{

    // A generic data reader that's used by the repository, full description
    // for what this achieves in the ForecastRepository
    public interface IDataReader
    {
        public IEnumerable<IForecastData> GetData();
    }
}

