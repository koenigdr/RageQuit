using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RageQuit.Models.ViewModels.Account
{
    public class EditUserProfilePictureViewModel
    {
        public int id { get; set; }
        [Display(Name = "Username")]
        public string username { get; set; }
        [Display(Name = "Profile Picture")]
        public string profilePicture { get; set; }
    }
}