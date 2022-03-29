using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Athlete
    {
        public int AthleteId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public int CompetitionId { get; set; }

        public virtual Competition Competition { get; set; }
    }
}
