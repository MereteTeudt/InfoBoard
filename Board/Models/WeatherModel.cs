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
        public string Icon {get; set;}

        public string Temp { get; set; }

        public string TempHigh { get; set; }

        public string TempLow { get; set; }

        public string Day { get; set; }
    }
}