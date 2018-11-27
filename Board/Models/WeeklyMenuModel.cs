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
            Monday = new MealModel();

            Tuesday = new MealModel();

            Wednesday = new MealModel();

            Thursday = new MealModel();

            Friday = new MealModel();

            Week = new List<MealModel>
            {
                Monday,
                Tuesday,
                Wednesday,
                Thursday,
                Friday
            };

            DayToday = DateTime.Now;

            Today = new MealModel();
        }
        public MealModel Monday { get; set; }

        public MealModel Tuesday { get; set; }

        public MealModel Wednesday { get; set; }

        public MealModel Thursday { get; set; }

        public MealModel Friday { get; set; }

        public MealModel Today { get; set; }

        public static List<MealModel> Week { get; set; }

        public static DateTime DayToday { get; set; }

        public static MealModel GetTodaysMeal(InfoBoardModel model)
        {
            MealModel todaysMeal = new MealModel();
            string today = DayToday.ToString("dddd");
            if(today == "mandag")
            {
                todaysMeal = model.WeeklyMenu.Monday;
            }
            else if(today == "tirsdag")
            {
                todaysMeal = model.WeeklyMenu.Tuesday;
            }
            else if (today == "onsdag")
            {
                todaysMeal = model.WeeklyMenu.Wednesday;
            }
            else if (today == "torsdag")
            {
                todaysMeal = model.WeeklyMenu.Thursday;
            }
            else
            {
                todaysMeal = model.WeeklyMenu.Friday;
            }

            return todaysMeal;
        }
    }
}