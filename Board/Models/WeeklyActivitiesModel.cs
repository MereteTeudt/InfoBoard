using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board.Models
{
    public class WeeklyActivitiesModel
    {
        public WeeklyActivitiesModel()
        {
            Quote = new QuoteModel();
            Assembly = new AssemblyModel();
            Friday = new FridayActivity();
        }
        public QuoteModel Quote { get; set; }

        public AssemblyModel Assembly { get; set; }

        public FridayActivity Friday { get; set; }
    }
}