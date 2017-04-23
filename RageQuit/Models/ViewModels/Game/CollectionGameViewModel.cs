using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RageQuit.Models.ViewModels.Game
{
    public class CollectionGameViewModel
    {
        public List<PageGameViewModel> upcomingGames { get; set; }
        public List<PageGameViewModel> ratingGames { get; set; }
    }
}