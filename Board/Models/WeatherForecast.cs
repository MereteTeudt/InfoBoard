using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static System.Globalization.NumberStyles;
using System.Web;

namespace Board.Models
{
    public class WeatherForecast
    {
        public WeatherForecast()
        {
            InitializeClient();
        }
        public List<WeatherModel> WeatherModels { get; set; }

        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            //New instance of HttpClient. HttpClient class provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.
            ApiClient = new HttpClient();
            //Clears the Accept field in the header
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            // Adds a request for a response in json format so that it can be parsed into a model
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<List<WeatherModel>> LoadWeatherForecast()
        {
            string url = "https://api.openweathermap.org/data/2.5/forecast?id=2610601&units=metric&APPID=f875a4257eb28c788895b2abd208672e";
            using (HttpResponseMessage response = await ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    JObject jObject = JObject.Parse(result);
                    WeatherModel weatherNow = new WeatherModel();
                    weatherNow.Day = DateTime.Today.DayOfWeek.ToString();
                    var iconCodeNow = jObject["list"][0]["weather"][0]["icon"];
                    string code = iconCodeNow.ToString();
                    string noLetter = code.Remove(code.Length - 1);
                    weatherNow.Icon = GetIconClass(noLetter + "d");
                    var tempNow = jObject["list"][0]["main"]["temp"];
                    double doubleTemp = double.Parse(tempNow.ToString());
                    weatherNow.Temp = Math.Round(doubleTemp, 1).ToString();

                    List<WeatherModel> weathersTwo = new List<WeatherModel>();
                    List<WeatherModel> weathersThree = new List<WeatherModel>();
                    List<WeatherModel> weathersFour = new List<WeatherModel>();
                    List<WeatherModel> weathersFive = new List<WeatherModel>();

                    foreach (JObject j in jObject["list"])
                    {
                        WeatherModel weatherModel = new WeatherModel();
                        var unixDate = j["dt"];
                        int unixInt;
                        bool success = Int32.TryParse(unixDate.ToString(), out unixInt);
                        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixInt);
                        DateTime date = dateTimeOffset.UtcDateTime;
                        weatherModel.Day = date.DayOfWeek.ToString();
                        if (date.Date == DateTime.Today.AddDays(1))
                        {
                            var iconCode = j["weather"][0]["icon"];
                            weatherModel.Icon = iconCode.ToString();
                            var temp = j["main"]["temp"];
                            weatherModel.Temp = temp.ToString();
                            weathersTwo.Add(weatherModel);
                        }
                        else if (date.Date == DateTime.Today.AddDays(2))
                        {
                            var iconCode = j["weather"][0]["icon"];
                            weatherModel.Icon = iconCode.ToString();
                            var temp = j["main"]["temp"];
                            weatherModel.Temp = temp.ToString();
                            weathersThree.Add(weatherModel);
                        }
                        else if (date.Date == DateTime.Today.AddDays(3))
                        {
                            var iconCode = j["weather"][0]["icon"];
                            weatherModel.Icon = iconCode.ToString();
                            var temp = j["main"]["temp"];
                            weatherModel.Temp = temp.ToString();
                            weathersFour.Add(weatherModel);
                        }
                        else if (date.Date == DateTime.Today.AddDays(4))
                        {
                            var iconCode = j["weather"][0]["icon"];
                            weatherModel.Icon = iconCode.ToString();
                            var temp = j["main"]["temp"];
                            weatherModel.Temp = temp.ToString();
                            weathersFive.Add(weatherModel);
                        }
                        else
                        {

                        }
                    }

                    WeatherModel weatherDayTwo = CalcWeatherOfDay(weathersTwo);
                    WeatherModel weatherDayThree = CalcWeatherOfDay(weathersThree);
                    WeatherModel weatherDayFour = CalcWeatherOfDay(weathersFour);
                    WeatherModel weatherDayFive = CalcWeatherOfDay(weathersFive);

                    List<WeatherModel> weatherForecast = new List<WeatherModel>(new WeatherModel[] 
                    { weatherNow, weatherDayTwo, weatherDayThree, weatherDayFour, weatherDayFive });
                    return weatherForecast;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static WeatherModel CalcWeatherOfDay(List<WeatherModel> weathers)
        {
            WeatherModel weatherModel = new WeatherModel();
            List<decimal> temps = new List<decimal>();
            foreach (WeatherModel weather in weathers)
            {
                decimal decTemp = Decimal.Parse(weather.Temp);
                temps.Add(decTemp);
            }
            List<double> intIconCodes = new List<double>();
            for (int i = 3; i < 8; i++)
            {
                string icon = weathers[i].Icon;
                string withoutLetter = icon.Remove(icon.Length - 1);
                double code = double.Parse(withoutLetter);
                intIconCodes.Add(code);
            }
            weatherModel.TempHigh = Math.Round(temps.Max(), 1).ToString();
            weatherModel.TempLow = Math.Round(temps.Min(), 1).ToString();
            double chosenIcon = intIconCodes.Max();
            if (chosenIcon < 10)
            {
                weatherModel.Icon = GetIconClass("0" + intIconCodes.Max().ToString() + "d");
            }
            else
            {
                weatherModel.Icon = GetIconClass(intIconCodes.Max().ToString() + "d");
            }

            weatherModel.Day = weathers[0].Day;

            return weatherModel;
        }
        public static string GetIconClass(string iconCode)
        {
            string icon = "";
            switch (iconCode)
            {
                case ("01d"):
                    {
                        icon = "day-sunny";
                        break;
                    }
                case "02d":
                    {
                        icon = "day-sunny-overcast";
                        break;
                    }
                case "03d":
                    {
                        icon = "cloud";
                        break;
                    }
                case "04d":
                    {
                        icon = "cloudy";
                        break;
                    }
                case "09d":
                    {
                        icon = "showers";
                        break;
                    }
                case "10d":
                    {
                        icon = "rain";
                        break;
                    }
                case "11d":
                    {
                        icon = "thunderstorm";
                        break;
                    }
                case "13d":
                    {
                        icon = "snow";
                        break;
                    }
                case "50d":
                    {
                        icon = "fog";
                        break;
                    }

            }
            icon = "wi wi-" + icon;
            return icon;
        }
    }
}