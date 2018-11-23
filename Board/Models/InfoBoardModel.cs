using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board.Models
{
    public class InfoBoardModel
    {
        public string CurrentWeek = (DateTime.Now.DayOfYear / 7).ToString();

        public WeeklyMenuModel WeeklyMenu { get; set; }

        public WeeklyThemeModel WeeklyTheme { get; set; }
    }
}