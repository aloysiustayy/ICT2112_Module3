using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public partial class Prescription
    {
        public long DrugId { get; set; }
        public virtual Drug Drug { get; set; } = null!;

        public long MedicationTrackerId { get; set; }
        public virtual MedicationTracker MedicationTracker { get; set; } = null!;

        public long PatientMedicalPlanId { get; set; }
        public virtual PatientMedicalPlan PatientMedicalPlan { get; set; } = null!;
    }
}