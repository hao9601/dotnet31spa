using System;
using System.Data.SQLite;

namespace dotnet31spa.DataAccess
{
    public class BaseRepository
    {
        public static string DbFile => Environment.CurrentDirectory + "\\WeatherForecast.db";

        public static SQLiteConnection DbConnection()
        {
            return new SQLiteConnection("Data Source=" + DbFile);
        }
    }
}