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
            infoBoardModel.WeeklyTheme.Assembly.ImagePath = "~/Images/logo.png";

            infoBoardModel.WeeklyMenu.Monday = new MealModel("Boller i karry", "www.karolines.dk/boller_i_karry", "~/Images/InfoBoardFood/RecipeOne.jpeg");
            infoBoardModel.WeeklyMenu.Tuesday = new MealModel("Spaghetti og kødboller", "www.karolines.dk/spaghetti_og_kødboller", "~/Images/InfoBoardFood/RecipeThree.jpeg");
            infoBoardModel.WeeklyMenu.Wednesday = new MealModel("Ragout", "www.karolines.dk/ragout", "~/Images/InfoBoardFood/RecipeThree.jpeg");
            infoBoardModel.WeeklyMenu.Thursday = new MealModel("Lasagne", "www.karolines.dk/lasagne", "~/Images/InfoBoardFood/RecipeOne.jpeg");
            infoBoardModel.WeeklyMenu.Friday = new MealModel("Pizza", "www.karolines.dk/pizza", "~/Images/InfoBoardFood/RecipeThree.jpeg");

            return infoBoardModel;
        }
    }
}