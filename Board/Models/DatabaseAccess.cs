using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Board.Models
{
    public class DatabaseAccess
    {

        public static void Set(List<WeatherModel> w)
        {
            string connetionString;
            IDbConnection cnn;
            connetionString = @"Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = InfoBoard; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            foreach (WeatherModel model in w)
            {
                using (cnn = new SqlConnection(connetionString))
                {
                    cnn.Execute("insert into Weather (Icon, TempHigh, TempLow, Temp, Day) values (@Icon, @TempHigh, @TempLow, @Temp, @Day)",
                        new {
                            model.Icon,
                            model.TempHigh,
                            model.TempLow,
                            model.Temp,
                            model.Day
                        });
                }
            }
        }

        public static List<WeatherModel> Get()
        {
            List<WeatherModel> weatherModels = new List<WeatherModel>();
            string connetionString;
            IDbConnection cnn;
            connetionString = @"Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = InfoBoard; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            using (cnn = new SqlConnection(connetionString))
            {
                weatherModels = cnn.Query<WeatherModel>("select * from Weather").ToList();
            }
            return weatherModels;
        }
    }
}