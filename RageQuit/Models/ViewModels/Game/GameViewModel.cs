using RageQuit.Models.Data;
using RageQuit.Models.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RageQuit.Models.ViewModels.Game
{
    public class GameViewModel
    {
        public int id { get; set; }
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
        [Display(Name = "Genre")]
        public string genres { get; set; }
        [Display(Name = "Available On")]
        public string systems { get; set; }
        public List<GameCommentViewModel> commentVM { get; set; }
        public bool userHasRated { get; set; }
        public bool userLiked { get; set; }
        [Display(Name = "Rating")]
        public int rating { get; set; }
        public bool hasReleased { get; set; }
    }
}