using Dapper;
using Dapper.Contrib.Extensions;
using dotnet31spa.Controllers;
using dotnet31spa.DataAccess;
using Microsoft.Extensions.Logging;
using System;
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

        public async Task<bool> Delete(int id)
        {
            using SQLiteConnection cnn = DbConnection();
            cnn.Open();

            return await cnn.DeleteAsync(new WeatherForecast { Id = id }).ConfigureAwait(false);
        }

        public async Task<IEnumerable<WeatherForecast>> GetAllAsync()
        {
            if (!File.Exists(DbFile))
            {
                return null;
            }

            using SQLiteConnection cnn = DbConnection();
            cnn.Open();

            return await cnn.GetAllAsync<WeatherForecast>().ConfigureAwait(false);
        }

        public async Task<WeatherForecast> GetById(int id)
        {
            using SQLiteConnection cnn = DbConnection();
            cnn.Open();

            return await cnn.GetAsync<WeatherForecast>(id).ConfigureAwait(false);
        }

        public async Task<WeatherForecast> Insert(WeatherForecast weatherForecast)
        {
            if (weatherForecast == null)
            {
                throw new ArgumentNullException(nameof(weatherForecast));
            }

            using SQLiteConnection cnn = DbConnection();
            cnn.Open();

            weatherForecast.Id = await cnn.InsertAsync(weatherForecast).ConfigureAwait(false);

            return weatherForecast;
        }

        public async Task<WeatherForecast> Update(WeatherForecast weatherForecast)
        {
            if (weatherForecast == null)
            {
                throw new ArgumentNullException(nameof(weatherForecast));
            }

            using SQLiteConnection cnn = DbConnection();
            await cnn.UpdateAsync(weatherForecast).ConfigureAwait(false);

            return weatherForecast;
        }
    }
}