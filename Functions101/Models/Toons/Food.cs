using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Food
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public float UnitPrice { get; set; }
        public int FoodCategoryId { get; set; }

        public virtual FoodCategory FoodCategory { get; set; }
    }
}
