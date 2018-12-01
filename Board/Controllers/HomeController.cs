using Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Board.Controllers
{
    public class HomeController : Controller
    {
        public InfoBoardModel infoBoardModel = new InfoBoardModel();
        public async Task<ActionResult> Index()
        {
            infoBoardModel = InfoBoardModel.TestBoard();
            WeatherForecast weatherForecast = new WeatherForecast();
            weatherForecast.WeatherModels = await WeatherForecast.LoadWeatherForecast();
            infoBoardModel.Forecast = weatherForecast;
            return View("Index", infoBoardModel);
        }
    }
}