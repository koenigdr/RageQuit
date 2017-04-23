using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RageQuit.Models.ViewModels.Comment
{
    public class GameCommentViewModel : CommentViewModel
    {
        [Display(Name = "User")]
        public string username { get; set; }
        public int userId { get; set; }
    }
}