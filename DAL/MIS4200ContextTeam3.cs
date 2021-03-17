using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Team3SemesterProject.Models;

namespace Team3SemesterProject.DAL
{
    public class MIS4200ContextTeam3 : DbContext
    {
        public MIS4200ContextTeam3() : base("name=DefaultConnection")
        {

        }
        public DbSet<Profile> profile { get; set; }
        public DbSet<CoreValue> coreValue { get; set; }
        public DbSet<Leaderboard> leaderboard { get; set; }
    }
}