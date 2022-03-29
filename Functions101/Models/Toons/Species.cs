using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Species
    {
        public Species()
        {
            Organisms = new HashSet<Organism>();
        }

        public string SpecieName { get; set; }

        public virtual ICollection<Organism> Organisms { get; set; }
    }
}
