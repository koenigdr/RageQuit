using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RageQuit.Models.Data
{
    [Table("tblGame")]
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string title { get; set; }
        public string coverArt { get; set; }
        public string description { get; set; }
        public string developer { get; set; }
        public string publisher { get; set; }
        public DateTime releaseDate { get; set; }
        public bool isAction { get; set; }
        public bool isAdventure { get; set; }
        public bool isFighting { get; set; }
        public bool isFlying { get; set; }
        public bool isParty { get; set; }
        public bool isPlatformer { get; set; }
        public bool isPuzzle { get; set; }
        public bool isRacing { get; set; }
        public bool isRolePlaying { get; set; }
        public bool isMMO { get; set; }
        public bool isShooter { get; set; }
        public bool isSimulation { get; set; }
        public bool isSport { get; set; }
        public bool isStealth { get; set; }
        public bool isStrategy { get; set; }
        public bool isSurvivalHorror { get; set; }
        public bool isOnSwitch { get; set; }
        public bool isOnXboxOne { get; set; }
        public bool isOnPS4 { get; set; }
        public bool isOnPC { get; set; }
        public bool isOnMac { get; set; }
        public bool isOnNew3DS { get; set; }
        public bool isOnWiiU { get; set; }
        public bool isOnXbox360 { get; set; }
        public bool isOnPS3 { get; set; }
        public bool isOnWii { get; set; }
        public bool isOn3DS { get; set; }
        public bool isOnVita { get; set; }
        public bool isOnDS { get; set; }
        public bool isOnPSP { get; set; }
        public bool isOnIPhone { get; set; }
        public bool isOnAndroid { get; set; }
        public bool isOnGameboyAdvanced { get; set; }
        public bool isOnXbox { get; set; }
        public bool isOnPlaystation2 { get; set; }
        public bool isOnGameCube { get; set; }
        public bool isOnPlaystation { get; set; }
        public bool isOnNintendo64 { get; set; }
        public bool isOnNGage { get; set; }
        public bool isOnDreamcast { get; set; }
        public bool isOnGameboy { get; set; }
        public bool isActive { get; set; }
    }
}