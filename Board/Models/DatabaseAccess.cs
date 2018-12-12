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

        public static InfoBoardModel GetInfoBoard()
        {
             InfoBoardModel infoBoard = new InfoBoardModel();
            QuoteModel quote = new QuoteModel();
            AssemblyModel assembly = new AssemblyModel();
            FridayActivity friday = new FridayActivity();
            List<MealModel> meals = new List<MealModel>();
            using (IDbConnection connection = new SqlConnection(ConString("InfoBoard")))
            {
                quote = connection.QuerySingle<QuoteModel>("select * from Quote where Id = 1");
                assembly = connection.QuerySingle<AssemblyModel>("select * from Assembly where Id = 1");
                friday = connection.QuerySingle<FridayActivity>("select * from Friday where Id = 1");
                meals = connection.Query<MealModel>("select * from Menu").ToList();
            }
            infoBoard.WeeklyActivities.Quote = quote;
            infoBoard.WeeklyActivities.Assembly = assembly;
            infoBoard.WeeklyActivities.Friday = friday;
            for (int i = 0; i < 5; i++)
            {
                infoBoard.WeeklyMenu.Week.Add(meals[i]);
            }
            infoBoard.WeeklyMenu.Today = WeeklyMenuModel.GetTodaysMeal(infoBoard);
            return infoBoard;
        }

        public static void SetInfoBoard(InfoBoardModel infoBoard)
        {
            using (IDbConnection connection = new SqlConnection(ConString("InfoBoard")))
            {
                connection.Execute(@"update Quote set QuoteText = @QuoteText, QuoteAuthor = @QuoteAuthor where Id = 1", new
                {
                    infoBoard.WeeklyActivities.Quote.QuoteText,
                    infoBoard.WeeklyActivities.Quote.QuoteAuthor
                });

                connection.Execute(@"update Assembly set AssemblyTheme = @AssemblyTheme, ImagePath = @ImagePath where Id = 1", new
                {
                    infoBoard.WeeklyActivities.Assembly.AssemblyTheme,
                    infoBoard.WeeklyActivities.Assembly.ImagePath
                });

                connection.Execute(@"update Friday set Name = @Name, ImagePath = @ImagePath where Id = 1", new
                {
                    infoBoard.WeeklyActivities.Friday.Name,
                    infoBoard.WeeklyActivities.Friday.ImagePath
                });
                int Id = 1;
                for (int i = 0; i < 5; i++)
                {
                    connection.Execute(@"update Menu set Name = @Name, RecipePath = @RecipePath, ImagePath = @ImagePath where Id = @Id", new
                    {
                        infoBoard.WeeklyMenu.Week[i].Name,
                        infoBoard.WeeklyMenu.Week[i].RecipePath,
                        infoBoard.WeeklyMenu.Week[i].ImagePath,
                        Id
                    });
                    Id++;
                }
            }
        }

        public static async Task<bool> SetWeather()
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

        public static List<WeatherModel> GetWeather()
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