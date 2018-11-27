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

        public static InfoBoardModel TestBoard()
        {
            InfoBoardModel infoBoardModel = new InfoBoardModel();

            infoBoardModel.WeeklyTheme.Quote = new QuoteModel();
            infoBoardModel.WeeklyTheme.Quote.QuoteText = "I hear and I forget. I see and I remember. I do and I understand.";
            infoBoardModel.WeeklyTheme.Quote.QuoteAuthor = "Confucius";

            infoBoardModel.WeeklyTheme.Assembly = new AssemblyModel();
            infoBoardModel.WeeklyTheme.Assembly.AssemblyTheme = "Flex-job";
            infoBoardModel.WeeklyTheme.Assembly.ImagePath = "~/Images/default-image.jpg";

            infoBoardModel.WeeklyMenu.Monday = new MealModel("Boller i karry", "https://www.w3schools.com/", "~/Images/InfoBoardFood/RecipeOne.jpeg");
            infoBoardModel.WeeklyMenu.Tuesday = new MealModel("Spaghetti og kødboller", "https://www.w3schools.com/", "~/Images/InfoBoardFood/RecipeThree.jpeg");
            infoBoardModel.WeeklyMenu.Wednesday = new MealModel("Ragout", "https://www.w3schools.com/", "~/Images/InfoBoardFood/RecipeThree.jpeg");
            infoBoardModel.WeeklyMenu.Thursday = new MealModel("Lasagne", "https://www.w3schools.com/", "~/Images/InfoBoardFood/RecipeOne.jpeg");
            infoBoardModel.WeeklyMenu.Friday = new MealModel("Pizza", "https://www.w3schools.com/", "~/Images/InfoBoardFood/RecipeThree.jpeg");
            infoBoardModel.weeklyMenu.Today = WeeklyMenuModel.GetTodaysMeal(infoBoardModel);
            return infoBoardModel;
        }
    }
}