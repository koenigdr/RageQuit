using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RageQuit.Models.ViewModels.Comment
{
    public class CommentViewModel
    {
        public int id { get; set; }
        [Display(Name = "Comment")]
        public string comment { get; set; }
        [Display(Name = "Rating")]
        public bool isLiked { get; set; }
    }
}