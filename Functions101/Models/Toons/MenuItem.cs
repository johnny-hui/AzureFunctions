using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class MenuItem
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
