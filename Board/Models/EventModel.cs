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
            HideImages = "";
        }
        public string EventText;

        public string HideImages;
    }
}