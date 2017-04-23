using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RageQuit.Models.ViewModels.Comment
{
    public class UserCommentViewModel : CommentViewModel
    {
        public int gameId { get; set; }
        [Display(Name = "Game")]
        public string gameTitle { get; set; }
        [Display(Name = "Delete")]
        public bool isSelected { get; set; }
    }
}