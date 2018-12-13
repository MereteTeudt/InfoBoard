using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board.Models
{
    public class EventModel
    {
        public EventModel()
        {
            EventText = "";
            MarginClass = "BigMarginClass";
            VacationDate = DateTime.Now.Date;
        }
        public string EventText { get; set; }
        public string ImageClass { get; set; }

        public string MarginClass { get; set; }

        public DateTime VacationDate { get; set; }

        public string GetImageClass()
        {
            string hideClass = "";
            if(!string.IsNullOrWhiteSpace(EventText))
            {
                hideClass = "hidePictures";
                MarginClass = "SmallBodyMargin";
            }
            return hideClass;
        }
    }
}