using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class PatientMedicalPlan
{
    public long MedicalPlanId { get; set; }

    public string MedicalPlanDescription { get; set; } = null!;

    public long PatientId { get; set; }

    public long DrugId { get; set; }

    public virtual ICollection<DischargeRecord> DischargeRecords { get; set; } = new List<DischargeRecord>();

    public virtual Drug Drug { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
