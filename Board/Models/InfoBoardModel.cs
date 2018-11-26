using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board.Models
{
    public class InfoBoardModel
    {
        private WeeklyMenuModel weeklyMenu;

        private WeeklyThemeModel weeklyTheme;

        public InfoBoardModel()
        {
            CurrentWeek = (DateTime.Now.DayOfYear / 7).ToString();
            WeeklyTheme = new WeeklyThemeModel();
            WeeklyMenu = new WeeklyMenuModel();
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

        public static InfoBoardModel testBoard()
        {
            InfoBoardModel infoBoardModel = new InfoBoardModel();

            infoBoardModel.WeeklyTheme.Quote = new QuoteModel();
            infoBoardModel.WeeklyTheme.Quote.QuoteText = "I hear and I forget. I see and I remember. I do and I understand.";
            infoBoardModel.WeeklyTheme.Quote.QuoteAuthor = "Confucius";

            infoBoardModel.WeeklyTheme.Assembly = new AssemblyModel();
            infoBoardModel.WeeklyTheme.Assembly.AssemblyTheme = "Flex-job";
            infoBoardModel.WeeklyTheme.Assembly.ImagePath = "TestData";

            infoBoardModel.WeeklyMenu.Monday = new MealModel("Boller i karry", "www.karolines.dk/boller_i_karry", "www.karolines.dk/boller_i_karry_img");
            infoBoardModel.WeeklyMenu.Tuesday = new MealModel("Spaghetti og kødboller", "www.karolines.dk/spaghetti_og_kødboller", "www.karolines.dk/spaghetti_og_kødboller_img");
            infoBoardModel.WeeklyMenu.Wednesday = new MealModel("Ragout", "www.karolines.dk/ragout", "www.karolines.dk/ragout_img");
            infoBoardModel.WeeklyMenu.Thursday = new MealModel("Lasagne", "www.karolines.dk/lasagne", "www.karolines.dk/lasagne_img");
            infoBoardModel.WeeklyMenu.Friday = new MealModel("Pizza", "www.karolines.dk/pizza", "www.karolines.dk/pizza_img");

            return infoBoardModel;
        }
    }
}