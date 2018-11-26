using Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Board.Controllers
{
    public class AdministrationController : Controller
    {
        public InfoBoardModel infoBoardModel = new InfoBoardModel();
        // GET: Administration
        public ActionResult Index()
        {
            infoBoardModel = InfoBoardModel.testBoard();
            return View("Index", infoBoardModel);
        }

        public ActionResult EditQuote(InfoBoardModel infoBoard)
        {
            infoBoardModel.WeeklyTheme.Quote = infoBoard.WeeklyTheme.Quote;
            return View("Index", infoBoardModel);
        }

        public ActionResult EditTheme(InfoBoardModel infoBoard)
        {
            infoBoardModel.WeeklyTheme.Assembly = infoBoard.WeeklyTheme.Assembly;
            return View("Index", infoBoardModel);
        }

        public ActionResult EditMenu(InfoBoardModel infoBoard)
        {
            infoBoardModel.WeeklyMenu = infoBoard.WeeklyMenu;
            return View("Index", infoBoardModel);
        }
    }
}