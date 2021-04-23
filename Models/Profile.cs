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
        [Display(Name ="Last Name")]
        public string lastName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Full Name")]
        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }
        [Display(Name = "Office")]
        public string office { get; set; }
        [Display(Name = "Position")]
        public string position { get; set; }
        [DisplayFormat (DataFormatString ="{0:d}")]
        [Display(Name = "Hire Date")]
        public DateTime hireDate { get; set; }
        public ICollection<Leaderboard> leaderboard { get; set; }
    }
}