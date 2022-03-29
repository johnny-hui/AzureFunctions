using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Hospital
    {
        public Hospital()
        {
            Patients = new HashSet<Patient>();
        }

        public int HospitalId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
