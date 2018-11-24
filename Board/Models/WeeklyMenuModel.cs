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
        }

        public MealModel Monday { get; set; }

        public MealModel Tuesday { get; set; }

        public MealModel Wednesday { get; set; }

        public MealModel Thursday { get; set; }

        public MealModel Friday { get; set; }
    }
}