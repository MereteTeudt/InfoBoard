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
            QuoteText = "QuoteText";

            QuoteAuthor = "QuoteAuthor";
        }
        public string QuoteText { get; set; }

        public string QuoteAuthor { get; set; }
    }
}