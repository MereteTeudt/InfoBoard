using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board.Models
{
    public class MealModel
    {
        public MealModel(string name, string recipe, string image)
        {
            Name = name;

            RecipePath = recipe;

            ImagePath = image;
        }

        public MealModel()
        {
            Name = "Ingen data";

            RecipePath = "Ingen data";

            ImagePath = "~/Images/default-image.jpg";
        }

        public string Name { get; set; }

        public string RecipePath { get; set; }

        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}