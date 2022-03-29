using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class City
    {
        public string CityName { get; set; }
        public int ProvinceId { get; set; }

        public virtual Province Province { get; set; }
    }
}
