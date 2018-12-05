using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Board.Models
{
    public class APIData
    {
        public static WeatherModel FormatJSON(JObject j)
        {
            WeatherModel weatherModel = new WeatherModel();
            var iconCode = j["weather"][0]["icon"];
            weatherModel.Icon = iconCode.ToString();
            var temp = j["main"]["temp"];
            weatherModel.Temp = temp.ToString();
            return weatherModel;
        }

        public static async Task<List<WeatherModel>> LoadWeatherForecast()
        {
            List<WeatherModel> weatherForecast;

            string url = "https://api.openweathermap.org/data/2.5/forecast?id=2610601&units=metric&APPID=f875a4257eb28c788895b2abd208672e";
            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<List<WeatherModel>> weatherModelList = new List<List<WeatherModel>>()
                    {
                        new List<WeatherModel>(),
                        new List<WeatherModel>(),
                        new List<WeatherModel>(),
                        new List<WeatherModel>()
                    };

                    string result = await response.Content.ReadAsStringAsync();
                    JObject jObject = JObject.Parse(result);
                    WeatherModel weatherNow = new WeatherModel();
                    weatherNow.Day = DateTime.Today.DayOfWeek.ToString();
                    var iconCodeNow = jObject["list"][0]["weather"][0]["icon"];
                    string code = iconCodeNow.ToString();
                    string noLetter = code.Remove(code.Length - 1);
                    weatherNow.Icon = WeatherCalc.GetIconClass(noLetter + "d");
                    var tempNow = jObject["list"][0]["main"]["temp"];
                    double doubleTemp = double.Parse(tempNow.ToString());
                    weatherNow.Temp = Math.Round(doubleTemp, 1).ToString();

                    foreach (JObject j in jObject["list"])
                    {
                        WeatherModel weatherModel = new WeatherModel();
                        var unixDate = j["dt"];
                        int unixInt;
                        bool success = Int32.TryParse(unixDate.ToString(), out unixInt);
                        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixInt);
                        DateTime date = dateTimeOffset.UtcDateTime;

                        if (date.Date == DateTime.Today.AddDays(1))
                        {
                            weatherModel = FormatJSON(j);
                            weatherModel.Day = date.DayOfWeek.ToString();
                            weatherModelList[0].Add(weatherModel);
                        }
                        else if (date.Date == DateTime.Today.AddDays(2))
                        {
                            weatherModel = FormatJSON(j);
                            weatherModel.Day = date.DayOfWeek.ToString();
                            weatherModelList[1].Add(weatherModel);
                        }
                        else if (date.Date == DateTime.Today.AddDays(3))
                        {
                            weatherModel = FormatJSON(j);
                            weatherModel.Day = date.DayOfWeek.ToString();
                            weatherModelList[2].Add(weatherModel);
                        }
                        else if (date.Date == DateTime.Today.AddDays(4))
                        {
                            weatherModel = FormatJSON(j);
                            weatherModel.Day = date.DayOfWeek.ToString();
                            weatherModelList[3].Add(weatherModel);
                        }
                        else
                        {

                        }
                    }

                    weatherForecast = new List<WeatherModel>()
                    {
                        weatherNow,
                        WeatherCalc.CalcWeatherOfDay(weatherModelList[0]),
                        WeatherCalc.CalcWeatherOfDay(weatherModelList[1]),
                        WeatherCalc.CalcWeatherOfDay(weatherModelList[2]),
                        WeatherCalc.CalcWeatherOfDay(weatherModelList[3])
                    };

                    return weatherForecast;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}