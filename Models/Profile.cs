using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team3SemesterProject.Models
{
    public class Profile
    {
        public Guid profileID { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string firstName { get; set; }
        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }
        public string office { get; set; }
        public string position { get; set; }
        public DateTime hireDate { get; set; }
        public ICollection<Leaderboard> leaderboard { get; set; }
    }
}