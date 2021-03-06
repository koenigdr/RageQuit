﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RageQuit.Models.ViewModels.Account
{
    public class CreateUserViewModel
    {
        [Display(Name = "Username")]
        public string username { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Confirm Password")]
        public string confirmPassword { get; set; }
    }
}