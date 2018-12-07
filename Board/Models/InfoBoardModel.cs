using System;
using System.Collections.Generic;
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
        }

        public string CurrentWeek { get; set; }

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

    }
}