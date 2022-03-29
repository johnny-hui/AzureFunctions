using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class VehicleManufacturer
    {
        public VehicleManufacturer()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public string VehicleManufacturerName { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
