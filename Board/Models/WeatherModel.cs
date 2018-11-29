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
    public class WeatherModel
    {
        public WeatherModel()
        {
            InitializeClient();
        }

        public string Icon {get; set;}

        public string Temp { get; set; }

        public string Name { get; set; }

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

        public static async Task<WeatherModel> LoadWeatherInfo()
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?id=2610601&units=metric&APPID=f875a4257eb28c788895b2abd208672e";
            WeatherModel weatherModel = new WeatherModel();
            using (HttpResponseMessage response = await ApiClient.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    JObject jObject = JObject.Parse(result);
                    var iconCode = jObject["weather"][0]["icon"];
                    weatherModel.Icon = weatherModel.GetIconPath(iconCode.ToString());

                    var temp = jObject["main"]["temp"];
                    weatherModel.Temp = temp.ToString();

                    var name = jObject["name"];
                    weatherModel.Name = name.ToString();

                    return weatherModel;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public string GetIconPath(string iconCode)
        {
            string icon = "";
            switch(iconCode)
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