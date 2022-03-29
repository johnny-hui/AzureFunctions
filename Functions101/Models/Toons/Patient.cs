using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Patient
    {
        public Patient()
        {
            Sicknesses = new HashSet<Sickness>();
        }

        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RoomNumber { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public int HospitalId { get; set; }

        public virtual Hospital Hospital { get; set; }
        public virtual ICollection<Sickness> Sicknesses { get; set; }
    }
}
