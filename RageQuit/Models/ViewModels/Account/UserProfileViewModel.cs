using RageQuit.Models.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RageQuit.Models.ViewModels.Account
{
    public class UserProfileViewModel
    {
        [Display(Name = "Username")]
        public string username { get; set; }
        [Display(Name = "Profile Picture")]
        public string profilePicture { get; set; }
        [Display(Name = "Date Created")]
        public DateTime dateCreated { get; set; }
        public List<UserCommentViewModel> commentVM { get; set; }
    }
}