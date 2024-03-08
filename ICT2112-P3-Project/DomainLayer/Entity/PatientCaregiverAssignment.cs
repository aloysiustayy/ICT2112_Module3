using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class PatientCaregiverAssignment
{
    public long PatientCaregiverAssignmentId { get; set; }

    public string TimeAssigned { get; set; } = null!;

    public long PatientId { get; set; }

    public long PatientCaregiverId { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual PatientCaregiver PatientCaregiver { get; set; } = null!;
}
