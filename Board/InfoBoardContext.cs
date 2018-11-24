using Board.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Board
{
    public class InfoBoardContext : DbContext
    {
        public InfoBoardContext() : base()
        {

        }

        public DbSet<InfoBoardModel> InfoBoards { get; set; }

        public DbSet<WeeklyMenuModel> WeeklyMenus { get; set; }

        public DbSet<WeeklyThemeModel> WeeklyThemes { get; set; }

        public DbSet<QuoteModel> QuoteModels { get; set; }
        
        public DbSet<MealModel> MealModels { get; set; }
    }
}