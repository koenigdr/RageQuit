using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RageQuit.Models.ViewModels.Game
{
    public class SelectGameGenresViewModel
    {
        public int id { get; set; }
        [Display(Name = "Action")]
        public bool isAction { get; set; }
        [Display(Name = "Adventure")]
        public bool isAdventure { get; set; }
        [Display(Name = "Fighting")]
        public bool isFighting { get; set; }
        [Display(Name = "Flying")]
        public bool isFlying { get; set; }
        [Display(Name = "Party")]
        public bool isParty { get; set; }
        [Display(Name = "Platformer")]
        public bool isPlatformer { get; set; }
        [Display(Name = "Puzzle")]
        public bool isPuzzle { get; set; }
        [Display(Name = "Racing")]
        public bool isRacing { get; set; }
        [Display(Name = "Role-Playing")]
        public bool isRolePlaying { get; set; }
        [Display(Name = "MMO")]
        public bool isMMO { get; set; }
        [Display(Name = "Shooter")]
        public bool isShooter { get; set; }
        [Display(Name = "Simulation")]
        public bool isSimulation { get; set; }
        [Display(Name = "Sport")]
        public bool isSport { get; set; }
        [Display(Name = "Stealth")]
        public bool isStealth { get; set; }
        [Display(Name = "Strategy")]
        public bool isStrategy { get; set; }
        [Display(Name = "Survival Horror")]
        public bool isSurvivalHorror { get; set; }
    }
}