﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board.Models
{
    public class MealModel
    {
        public MealModel()
        {
            Name = "Name";

            RecipePath = "RecipePath";

            ImagePath = "ImagePath";
        }
        public string Name { get; set; }

        public string RecipePath { get; set; }

        public string ImagePath { get; set; }
    }
}