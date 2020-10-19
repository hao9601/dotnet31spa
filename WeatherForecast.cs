using Dapper.Contrib.Extensions;
using System;

namespace dotnet31spa
{
    [Table("WeatherForecast")]
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        [Key]
        public int Id { get; set; }

        public string Summary { get; set; }

        public int TemperatureC { get; set; }

        [Write(false)]
        [Computed]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}