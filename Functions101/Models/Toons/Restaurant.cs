using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            MenuItems = new HashSet<MenuItem>();
        }

        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string FoodType { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
