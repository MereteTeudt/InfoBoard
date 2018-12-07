using Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.WebHost;

namespace Board.Controllers
{
    public class WeatherAPIController : ApiController
    {
        public List<WeatherModel> WeatherModels { get; set; }

        // GET: api/WeatherAPI
        public List<WeatherModel> Get()
        {
            return DatabaseAccess.GetWeather();
        }
    }
}
