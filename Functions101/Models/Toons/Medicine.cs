using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Medicine
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public string DosageUnit { get; set; }
        public int Dosage { get; set; }
        public int SicknessId { get; set; }
        public int FrequencyInHours { get; set; }

        public virtual Sickness Sickness { get; set; }
    }
}
