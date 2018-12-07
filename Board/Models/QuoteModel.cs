using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board.Models
{
    public class QuoteModel
    {
        public QuoteModel()
        {
            QuoteText = "ingen data";

            QuoteAuthor = "ingen data";
        }
        public string QuoteText { get; set; }

        public string QuoteAuthor { get; set; }
    }
}