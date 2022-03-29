using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Sickness
    {
        public Sickness()
        {
            Medicines = new HashSet<Medicine>();
        }

        public int SicknessId { get; set; }
        public string SicknessName { get; set; }
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
