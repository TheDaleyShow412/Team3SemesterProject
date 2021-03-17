﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team3SemesterProject.Models
{
    public class Leaderboard
    {
        public int leaderboardID { get; set; }
        public Guid profileID { get; set; }
        public virtual Profile profile { get; set; }
        public int coreValueID { get; set; }
        public virtual CoreValue coreValue { get; set; }
        public string description { get; set; }

    }
}