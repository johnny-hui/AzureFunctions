using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }

        public string TeamName { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
