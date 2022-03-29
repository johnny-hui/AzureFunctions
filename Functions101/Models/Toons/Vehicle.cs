using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Vehicle
    {
        public string Model { get; set; }
        public string Fuel { get; set; }
        public string Type { get; set; }
        public string VehicleManufacturerName { get; set; }

        public virtual VehicleManufacturer VehicleManufacturerNameNavigation { get; set; }
    }
}
