using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Competition
    {
        public Competition()
        {
            Athletes = new HashSet<Athlete>();
        }

        public int CompetitionId { get; set; }
        public string EventName { get; set; }

        public virtual ICollection<Athlete> Athletes { get; set; }
    }
}
