using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static System.Globalization.NumberStyles;
using System.Web;
using System.Timers;

namespace Board.Models
{
    public class WeatherForecast
    {
        private static Timer timer;

        public WeatherForecast()
        {
            APIHelper.InitializeClient();
            timer = new Timer(60 * 60 * 1000);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        public List<WeatherModel> WeatherModels
        {
            get
            {
                return DatabaseAccess.Get();
            }
        }

        private static async void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            bool result = await DatabaseAccess.Set();
        }
    }
}