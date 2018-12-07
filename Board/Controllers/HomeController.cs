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
            bool result = await DatabaseAccess.SetWeather();
            infoBoardModel = DatabaseAccess.GetInfoBoard();
            return View("Index", infoBoardModel);
        }
    }
}