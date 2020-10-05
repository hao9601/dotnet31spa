using Dapper;
using dotnet31spa.Controllers;
using dotnet31spa.DataAccess;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;

namespace dotnet31spa.Repositories
{
    public class WeatherForecastRepository : BaseRepository
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastRepository(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<WeatherForecast>> GetAllAsync()
        {
            if (!File.Exists(DbFile))
            {
                return null;
            }

            using SQLiteConnection cnn = DbConnection();
            cnn.Open();

            return await cnn.QueryAsync<WeatherForecast>("SELECT * FROM WeatherForecast").ConfigureAwait(false);
        }
    }
}