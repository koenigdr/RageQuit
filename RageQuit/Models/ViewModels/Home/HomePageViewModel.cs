using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RageQuit.Models.ViewModels.Home
{
    public class HomePageViewModel
    {
        public List<HomePageGameViewModel> popularList { get; set; }
        public List<HomePageGameViewModel> ratedList { get; set; }
        public List<HomePageGameViewModel> upcomingList { get; set; }
    }
}