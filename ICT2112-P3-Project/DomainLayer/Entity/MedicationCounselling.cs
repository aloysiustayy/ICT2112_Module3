using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class MedicationCounselling
{
    public long MedicationCounsellingId { get; set; }

    public byte[] MedicationCounsellingChoice { get; set; } = null!;

    public string MedicationCounsellingDescription { get; set; } = null!;

    public long PatientId { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
