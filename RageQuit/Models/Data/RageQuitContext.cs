using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RageQuit.Models.Data
{
    public partial class RageQuitContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public RageQuitContext() : base("name=RageQuitDatabase")
        {
        }
    }
}