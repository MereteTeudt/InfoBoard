﻿using Newtonsoft.Json.Linq;
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

        public string IconPath {get; set;}

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
                    weatherModel.IconPath = weatherModel.GetIconPath(iconCode.ToString());

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
            string iconPath = "http://openweathermap.org/img/w/" + iconCode + ".png";
            return iconPath;
        }
    }
}