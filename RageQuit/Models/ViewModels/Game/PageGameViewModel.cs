using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RageQuit.Models.ViewModels.Game
{
    public class PageGameViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public int rating { get; set; }
        public DateTime releaseDate { get; set; }
    }
}