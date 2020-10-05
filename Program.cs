using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace dotnet31spa
{
    public class Program
    {
        public static void CreateDataBase()
        {
            string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var rng = new Random();

            string cs = Environment.CurrentDirectory + "\\WeatherForecast.db";
            SQLiteConnection.CreateFile(cs);

            using var con = new SQLiteConnection("URI=file:" + cs);
            con.Open();

            con.Execute("CREATE TABLE WeatherForecast(id INTEGER PRIMARY KEY, temperatureC INTEGER, date TEXT, summary TEXT)");

            Enumerable.Range(1, 9).ToList().ForEach(index =>
                con.Execute("INSERT INTO WeatherForecast(temperatureC, date, summary) VALUES(@temperatureC, @date, @summary)", new WeatherForecast { TemperatureC = rng.Next(-20, 55), Date = DateTime.Now.AddDays(index), Summary = Summaries[rng.Next(Summaries.Length)] })
            );
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

        public static void Main(string[] args)
        {
            CreateDataBase();
            CreateHostBuilder(args).Build().Run();
        }
    }
}