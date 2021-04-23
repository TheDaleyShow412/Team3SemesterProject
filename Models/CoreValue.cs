using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team3SemesterProject.Models
{
    public class CoreValue
    {
        public int coreValueID { get; set; }

        [Display(Name = "Core Value")]
        public string coreValueName { get; set;}
        public ICollection<Leaderboard> leaderboard { get; set; }
    }
}