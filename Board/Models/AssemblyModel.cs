using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board.Models
{
    public class AssemblyModel
    {
        public AssemblyModel()
        {
            AssemblyTheme = "ingen data";

            ImagePath = "~/Images/default-image.jpg";
        }
        public string AssemblyTheme { get; set; }

        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}