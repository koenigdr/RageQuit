using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RageQuit.Models.Data
{
    [Table("tblUser")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string profilePicture { get; set; }
        public DateTime dateCreated { get; set; }
        public bool isAdmin { get; set; }
        public bool isActive { get; set; }
    }
}