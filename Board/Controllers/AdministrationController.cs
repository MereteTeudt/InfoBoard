using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Board.Controllers
{
    public class AdministrationController : Controller
    {
        public Models.InfoBoardModel infoBoardModel = new Models.InfoBoardModel();
        // GET: Administration
        public ActionResult Index(Models.InfoBoardModel infoBoard)
        {
            infoBoard = infoBoardModel;
            return View("Index", infoBoard);
        }

        public ActionResult EditQuote(Models.QuoteModel quote)
        {
            infoBoardModel.WeeklyTheme.Quote = quote;
            return View();
        }

        public ActionResult EditTheme(Models.AssemblyModel assembly)
        {
            infoBoardModel.WeeklyTheme.Assembly = assembly;
            return View();
        }

        public ActionResult EditMenu(Models.WeeklyMenuModel menu)
        {
            infoBoardModel.WeeklyMenu = menu;
            return View();
        }
    }
}