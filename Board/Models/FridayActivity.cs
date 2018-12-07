using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board.Models
{
    public class FridayActivity
    {
        public FridayActivity()
        {
            Name = "Fri";

            ImagePath = "~/Images/friFredag.jpg";
        }
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}