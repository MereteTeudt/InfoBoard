using Board.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            infoBoardModel = InfoBoardModel.TestBoard();
            return View("Index", infoBoardModel);
        }

        public ActionResult EditQuote(InfoBoardModel infoBoard)
        {
            infoBoardModel.WeeklyActivities.Quote = infoBoard.WeeklyActivities.Quote;
            return View("Index", infoBoardModel);
        }

        public ActionResult EditTheme(InfoBoardModel infoBoard)
        {
            infoBoardModel.WeeklyActivities.Assembly = infoBoard.WeeklyActivities.Assembly;
            HttpPostedFileBase imageFile = infoBoardModel.WeeklyActivities.Assembly.ImageFile;

            string path = Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (imageFile != null)
            {
                string fileName = Path.GetFileName(imageFile.FileName);
                imageFile.SaveAs(path + fileName);
            }

            return View("Index", infoBoardModel);
        }

        public ActionResult EditMenu(InfoBoardModel infoBoard)
        {
            infoBoardModel.WeeklyMenu = infoBoard.WeeklyMenu;

            string path = Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (MealModel model in WeeklyMenuModel.Week)
            {
                HttpPostedFileBase imageFile = model.ImageFile;
                if (imageFile != null)
                {
                    string fileName = Path.GetFileName(imageFile.FileName);
                    imageFile.SaveAs(path + fileName);
                }
            }
            return View("Index", infoBoardModel);
        }
    }
}