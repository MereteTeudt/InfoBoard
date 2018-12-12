using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Board.Models
{
    public class InfoBoardModel
    {
        private WeeklyMenuModel weeklyMenu;

        private WeeklyActivitiesModel weeklyActivities;

        public InfoBoardModel()
        {
            APIHelper.InitializeClient();
            CurrentWeek = (DateTime.Now.DayOfYear / 7).ToString();
            WeeklyActivities = new WeeklyActivitiesModel();
            WeeklyMenu = new WeeklyMenuModel();
            Forecast = new WeatherForecast();
            Event = new EventModel();
        }

        public string CurrentWeek { get; set; }

        public EventModel Event { get; set; }

        public WeeklyMenuModel WeeklyMenu
        {
            get
            {
                return weeklyMenu;
            }
            set
            {
                weeklyMenu = value;
            }
        }

        public WeeklyActivitiesModel WeeklyActivities
        {
            get
            {
                return weeklyActivities;
            }
            set
            {
                weeklyActivities = value;
            }
        }

        public WeatherForecast Forecast { get; set; }

        public string UploadImage(HttpPostedFileBase imageFile, string mapPath)
        {
            if (!Directory.Exists(mapPath))
            {
                Directory.CreateDirectory(mapPath);
            }
            string fileName = Path.GetFileName(imageFile.FileName);
            mapPath += fileName;
            Image image = Image.FromStream(imageFile.InputStream, true, true);
            image.Save(mapPath);
            string path = "/Uploads/" + fileName;
            return path;
        }
    }
}