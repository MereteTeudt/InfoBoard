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

        public static InfoBoardModel TestBoard()
        {
            InfoBoardModel infoBoardModel = new InfoBoardModel();

            infoBoardModel.WeeklyActivities.Quote = new QuoteModel();
            infoBoardModel.WeeklyActivities.Quote.QuoteText = "I hear and I forget. I see and I remember. I do and I understand.";
            infoBoardModel.WeeklyActivities.Quote.QuoteAuthor = "Confucius";

            infoBoardModel.WeeklyActivities.Assembly = new AssemblyModel();
            infoBoardModel.WeeklyActivities.Assembly.AssemblyTheme = "Flex-job";
            infoBoardModel.WeeklyActivities.Assembly.ImagePath = "~/Images/default-image.jpg";

            infoBoardModel.WeeklyActivities.Friday = new FridayActivity();
            infoBoardModel.WeeklyActivities.Friday.Name = "Fri";
            infoBoardModel.WeeklyActivities.Assembly.ImagePath = "~/Images/default-image.jpg";

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