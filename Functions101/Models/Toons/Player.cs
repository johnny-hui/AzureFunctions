using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string TeamName { get; set; }

        public virtual Team TeamNameNavigation { get; set; }
    }
}
