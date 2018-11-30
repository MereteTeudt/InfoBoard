using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Board.Models
{
    public class WeatherForecast
    {
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
                WeatherModel weatherModel = new WeatherModel();
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    JObject jObject = JObject.Parse(result);
                    WeatherModel weatherNow = new WeatherModel();
                    weatherNow.Day = 1;
                    var iconCodeNow = jObject["weather"][0]["icon"];
                    weatherNow.Icon = weatherModel.GetIconPath(iconCodeNow.ToString());
                    var tempNow = jObject["main"]["temp"];
                    weatherNow.Temp = tempNow.ToString();

                    List<WeatherModel> weathersTwo = new List<WeatherModel>();
                    List<WeatherModel> weathersThree = new List<WeatherModel>();
                    List<WeatherModel> weathersFour = new List<WeatherModel>();
                    List<WeatherModel> weathersFive = new List<WeatherModel>();

                    foreach (JObject j in jObject["list"])
                    {

                        var unixDate = j["dt"];
                        int unixInt;
                        bool success = Int32.TryParse(unixDate.ToString(), out unixInt);
                        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixInt);
                        DateTime date = dateTimeOffset.UtcDateTime;
                        if (date == DateTime.Today.AddDays(1))
                        {
                            var iconCode = j["weather"][0]["icon"];
                            weatherModel.Icon = weatherModel.GetIconPath(iconCode.ToString());
                            var temp = j["main"]["temp"];
                            weatherModel.Temp = temp.ToString();
                            weathersTwo.Add(weatherModel);
                        }
                        else if (date == DateTime.Today.AddDays(2))
                        {
                            var iconCode = j["weather"][0]["icon"];
                            weatherModel.Icon = weatherModel.GetIconPath(iconCode.ToString());
                            var temp = j["main"]["temp"];
                            weatherModel.Temp = temp.ToString();
                            weathersThree.Add(weatherModel);
                        }
                        else if (date == DateTime.Today.AddDays(3))
                        {
                            var iconCode = j["weather"][0]["icon"];
                            weatherModel.Icon = weatherModel.GetIconPath(iconCode.ToString());
                            var temp = j["main"]["temp"];
                            weatherModel.Temp = temp.ToString();
                            weathersFour.Add(weatherModel);
                        }
                        else
                        {
                            var iconCode = j["weather"][0]["icon"];
                            weatherModel.Icon = weatherModel.GetIconPath(iconCode.ToString());
                            var temp = j["main"]["temp"];
                            weatherModel.Temp = temp.ToString();
                            weathersFive.Add(weatherModel);
                        }
                    }

                    WeatherModel weatherDayTwo = CalcWeatherOfDay(weathersTwo, 2);
                    WeatherModel weatherDayThree = CalcWeatherOfDay(weathersThree, 3);
                    WeatherModel weatherDayFour = CalcWeatherOfDay(weathersFour, 4);
                    WeatherModel weatherDayFive = CalcWeatherOfDay(weathersFive, 5);

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

        public static WeatherModel CalcWeatherOfDay(List<WeatherModel> weathers, int dayNumber)
        {
            WeatherModel weatherModel = new WeatherModel();
            List<int> temps = new List<int>();
            foreach (WeatherModel weather in weathers)
            {
                temps.Add(Int32.Parse(weather.Temp));
            }
            List<int> intIconCodes = new List<int>();
            for (int i = 3; i < 8; i++)
            {
                int code = Int32.Parse(weathers[i].Icon.Remove(weathers[i].Icon.Length - 1));
                intIconCodes.Add(code);
            }
            weatherModel.Day = dayNumber;
            weatherModel.TempHigh = temps.Max().ToString();
            weatherModel.TempLow = temps.Min().ToString();
            weatherModel.Icon = intIconCodes.Max().ToString() + "d";

            return weatherModel;
        }
        public string GetIconClass(string iconCode)
        {
            string icon = "";
            switch (iconCode)
            {
                case "01d":
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
            icon = "wi-" + icon;
            return icon;
        }
    }
}