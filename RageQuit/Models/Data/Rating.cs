using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RageQuit.Models.Data
{
    [Table("tblRating")]
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string comment { get; set; }
        public bool isLiked { get; set; }
        public bool isActive { get; set; }
        public int userId { get; set; }
        public string username { get; set; }
        public int gameId { get; set; }
        public string gameTitle { get; set; }
    }
}