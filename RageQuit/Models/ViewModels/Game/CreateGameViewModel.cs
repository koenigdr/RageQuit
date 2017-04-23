using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RageQuit.Models.ViewModels.Game
{
    public class CreateGameViewModel
    {
        [Display(Name = "Title")]
        public string title { get; set; }
        [Display(Name = "Cover Art")]
        public string coverArt { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Developer")]
        public string developer { get; set; }
        [Display(Name = "Publisher")]
        public string publisher { get; set; }
        [Display(Name = "Release Date")]
        public DateTime releaseDate { get; set; }
    }
}