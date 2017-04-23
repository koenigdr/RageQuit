using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RageQuit.Models.ViewModels.Game
{
    public class SelectGameSystemsViewModel
    {
        public int id { get; set; }
        [Display(Name = "Switch")]
        public bool isOnSwitch { get; set; }
        [Display(Name = "Xbox One")]
        public bool isOnXboxOne { get; set; }
        [Display(Name = "Playstation 4")]
        public bool isOnPS4 { get; set; }
        [Display(Name = "PC")]
        public bool isOnPC { get; set; }
        [Display(Name = "Mac")]
        public bool isOnMac { get; set; }
        [Display(Name = "New 3DS")]
        public bool isOnNew3DS { get; set; }
        [Display(Name = "Wii U")]
        public bool isOnWiiU { get; set; }
        [Display(Name = "Xbox 360")]
        public bool isOnXbox360 { get; set; }
        [Display(Name = "Playstation 3")]
        public bool isOnPS3 { get; set; }
        [Display(Name = "Wii")]
        public bool isOnWii { get; set; }
        [Display(Name = "3DS")]
        public bool isOn3DS { get; set; }
        [Display(Name = "Vita")]
        public bool isOnVita { get; set; }
        [Display(Name = "DS")]
        public bool isOnDS { get; set; }
        [Display(Name = "PSP")]
        public bool isOnPSP { get; set; }
        [Display(Name = "IPhone")]
        public bool isOnIPhone { get; set; }
        [Display(Name = "Android")]
        public bool isOnAndroid { get; set; }
        [Display(Name = "Gamboy Advanced")]
        public bool isOnGameboyAdvanced { get; set; }
        [Display(Name = "Xbox")]
        public bool isOnXbox { get; set; }
        [Display(Name = "Playstation 2")]
        public bool isOnPlaystation2 { get; set; }
        [Display(Name = "Game Cube")]
        public bool isOnGameCube { get; set; }
        [Display(Name = "Playstation")]
        public bool isOnPlaystation { get; set; }
        [Display(Name = "Nintendo 64")]
        public bool isOnNintendo64 { get; set; }
        [Display(Name = "N Gage")]
        public bool isOnNGage { get; set; }
        [Display(Name = "Dreamcast")]
        public bool isOnDreamcast { get; set; }
        [Display(Name = "Gameboy")]
        public bool isOnGameboy { get; set; }
    }
}