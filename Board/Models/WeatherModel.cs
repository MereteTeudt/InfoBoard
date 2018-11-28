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
        public int Temperature { get; set; }

        public string Icon { get; set; }

        public string Location { get; set; }

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

            using (HttpResponseMessage response = await ApiClient.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    WeatherModel weatherModel = await response.Content.ReadAsAsync<WeatherModel>();
                    return weatherModel;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}