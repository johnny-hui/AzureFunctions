using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Continent
    {
        public Continent()
        {
            Countries = new HashSet<Country>();
        }

        public string ContinentName { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
