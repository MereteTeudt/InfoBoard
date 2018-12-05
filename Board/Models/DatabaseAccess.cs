using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Board.Models
{
    public class DatabaseAccess
    {
        public static string ConString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static async Task<bool> Set()
        {
            List<WeatherModel> w = await APIData.LoadWeatherForecast();
            int id = 1;
            foreach (WeatherModel model in w)
            {
                using (IDbConnection connection = new SqlConnection(ConString("InfoBoard")))
                {
                    string updateQuery = @"update Weather set Icon = @Icon, TempHigh = @TempHigh, TempLow = @TempLow, Temp = @Temp, Day = @Day where Id = @Id";
                    var result = connection.Execute(updateQuery, new
                    {
                        model.Icon,
                        model.TempHigh,
                        model.TempLow,
                        model.Temp,
                        model.Day,
                        id
                    });
                }
                id++;
            }
            return true;
        }

        public static List<WeatherModel> Get()
        {
            List<WeatherModel> weatherModels = new List<WeatherModel>();
            using (IDbConnection connection = new SqlConnection(ConString("InfoBoard")))
            {
                weatherModels = connection.Query<WeatherModel>("select * from Weather").ToList();
            }
            return weatherModels;
        }
    }
}