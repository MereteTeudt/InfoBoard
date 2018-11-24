using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board.Models
{
    public class InfoBoardModel
    {
        private string currentWeek;

        private WeeklyMenuModel weeklyMenu;

        private WeeklyThemeModel weeklyTheme;

        public InfoBoardModel()
        {
            CurrentWeek = (DateTime.Now.DayOfYear / 7).ToString();
            WeeklyMenu = new WeeklyMenuModel();
            WeeklyTheme = new WeeklyThemeModel();
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

        public WeeklyThemeModel WeeklyTheme
        {
            get
            {
                return weeklyTheme;
            }
            set
            {
                weeklyTheme = value;
            }
        }
    }
}