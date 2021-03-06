﻿using Board.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Board.Controllers
{
    public class AdministrationController : Controller
    {
        public InfoBoardModel infoBoardModel = DatabaseAccess.GetInfoBoard();
        // GET: Administration
        public ActionResult Index()
        {
            return View("Index", infoBoardModel);
        }

        public ActionResult EditQuote(InfoBoardModel infoBoard)
        {
            infoBoardModel.WeeklyActivities.Quote = infoBoard.WeeklyActivities.Quote;
            DatabaseAccess.SetInfoBoard(infoBoardModel);
            return View("Index", infoBoardModel);
        }

        public ActionResult EditTheme(InfoBoardModel infoBoard)
        {
            string mapPath = Server.MapPath("~/Uploads/");
            infoBoardModel.WeeklyActivities.Assembly = infoBoard.WeeklyActivities.Assembly;
            HttpPostedFileBase imageFile = infoBoardModel.WeeklyActivities.Assembly.ImageFile;

            if (imageFile != null)
            {
                infoBoardModel.WeeklyActivities.Assembly.ImagePath = infoBoardModel.UploadImage(imageFile, mapPath);
            }
            DatabaseAccess.SetInfoBoard(infoBoardModel);
            return View("Index", infoBoardModel);
        }

        public ActionResult EditMenu(InfoBoardModel infoBoard)
        {
            string mapPath = Server.MapPath("~/Uploads/");

            for (int i = 0; i < 5; i++)
            {
                infoBoard.WeeklyMenu.Week[i].ImagePath = infoBoardModel.WeeklyMenu.Week[i].ImagePath;
                infoBoardModel.WeeklyMenu.Week[i] = infoBoard.WeeklyMenu.Week[i];
                HttpPostedFileBase imageFile = infoBoard.WeeklyMenu.Week[i].ImageFile;
                if (imageFile != null)
                {
                    infoBoardModel.WeeklyMenu.Week[i].ImagePath = infoBoardModel.UploadImage(imageFile, mapPath);
                }
            }
            DatabaseAccess.SetInfoBoard(infoBoardModel);
            return View("Index", infoBoardModel);
        }

        public ActionResult EditEvent(InfoBoardModel infoBoard)
        {
            infoBoardModel.Event.EventText = infoBoard.Event.EventText;
            infoBoardModel.Event.VacationDate = infoBoard.Event.VacationDate;
            DatabaseAccess.SetInfoBoard(infoBoardModel);
            return View("Index", infoBoardModel);
        }
    }
}