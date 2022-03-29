using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Province
    {
        public Province()
        {
            Cities = new HashSet<City>();
        }

        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public string CapitalCity { get; set; }
        public string CountryName { get; set; }

        public virtual Country CountryNameNavigation { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
