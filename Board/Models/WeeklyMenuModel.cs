using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board.Models
{
    public class WeeklyMenuModel
    {
        public WeeklyMenuModel()
        {
            Week = new List<MealModel>();
            Today = new MealModel();
            DayToday = DateTime.Today.DayOfWeek;
        }

        public List<MealModel> Week { get; set; }

        public MealModel Today { get; set; }

        public static DayOfWeek DayToday { get; set; }

        public static MealModel GetTodaysMeal(InfoBoardModel model)
        {
            MealModel todaysMeal = new MealModel();

            if (DayToday == DayOfWeek.Monday)
            {
                todaysMeal = model.WeeklyMenu.Week[0];
            }
            else if (DayToday == DayOfWeek.Tuesday)
            {
                todaysMeal = model.WeeklyMenu.Week[1];
            }
            else if (DayToday == DayOfWeek.Wednesday)
            {
                todaysMeal = model.WeeklyMenu.Week[2];
            }
            else if (DayToday == DayOfWeek.Thursday)
            {
                todaysMeal = model.WeeklyMenu.Week[3];
            }
            else
            {
                todaysMeal = model.WeeklyMenu.Week[4];
            }

            return todaysMeal;
        }
    }
}