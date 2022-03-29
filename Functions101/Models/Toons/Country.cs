using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Country
    {
        public Country()
        {
            Provinces = new HashSet<Province>();
        }

        public string CountryName { get; set; }
        public string CapitalCity { get; set; }
        public int AreaSqKm { get; set; }
        public string ContinentName { get; set; }

        public virtual Continent ContinentNameNavigation { get; set; }
        public virtual ICollection<Province> Provinces { get; set; }
    }
}
