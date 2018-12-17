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
            DaysForCountdown = 3;
        }
        public string EventText { get; set; }

        public string ImageClass { get; set; }

        public string DisplayInfoClass { get; set; }

        public string DisplayCountdownClass { get; set; }

        public string DisplayInfoBox { get; set; }

        public string MarginClass { get; set; }

        public DateTime VacationDate { get; set; }

        public int DaysForCountdown { get; set; }

        public string GetImageClass()
        {
            string hideClass = "";
            if(SetCountdown() || !string.IsNullOrWhiteSpace(EventText))
            {
                hideClass = "hidePictures";
                MarginClass = "SmallBodyMargin";
                DisplayInfoBox = "";
                SetInfoDisplay();
            }
            else
            {
                DisplayInfoBox = "d-none";
                MarginClass = "BigBodyMargin";
            }
            return hideClass;
        }

        public void SetInfoDisplay()
        {
            if(string.IsNullOrWhiteSpace(EventText))
            {
                DisplayInfoClass = "d-none";

            }
            else
            {
                DisplayInfoClass = "";

            }
        }

        public bool SetCountdown()
        {
            DateTime startCountdown = VacationDate.AddDays(-DaysForCountdown);
            if(startCountdown == DateTime.Today)
            {
                DisplayCountdownClass = "";
                return true;
            }
            else
            {
                DisplayCountdownClass = "d-none";
                return false;
            }
        }
    }
}