using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class PreDischargeServiceAssignment
{
    public long AssignmentId { get; set; }

    public string AssignmentDate { get; set; } = null!;

    public string AppointmentDate { get; set; } = null!;

    public long ServiceId { get; set; }

    public long PatientId { get; set; }

    public long DoctorId { get; set; }

    public long NurseId { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Nurse Nurse { get; set; } = null!;

    public virtual Nurse Patient { get; set; } = null!;

    public virtual ICollection<PreDischargeServiceSchedule> PreDischargeServiceSchedules { get; set; } = new List<PreDischargeServiceSchedule>();

    public virtual PreDischargeService Service { get; set; } = null!;
}
