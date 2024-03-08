using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class InPatientHistory
{
    public long InPatientId { get; set; }

    public string StayStartDate { get; set; } = null!;

    public string StayEndDate { get; set; } = null!;

    public long StayDuration { get; set; }

    public long PatientId { get; set; }

    public virtual ICollection<DischargeRecord> DischargeRecords { get; set; } = new List<DischargeRecord>();

    public virtual Patient Patient { get; set; } = null!;
}
