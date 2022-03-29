using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Organism
    {
        public int OrganismId { get; set; }
        public string Name { get; set; }
        public string SpecieName { get; set; }

        public virtual Species SpecieNameNavigation { get; set; }
    }
}
