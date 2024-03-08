using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class DischargeRecord
{
    public long DischargeId { get; set; }

    public string DischargeDate { get; set; } = null!;

    public string DischargeSummary { get; set; } = null!;

    public long FollowUpAppointmentId { get; set; }

    public long MedicalPlanId { get; set; }

    public long DocumentationId { get; set; }

    public long InPatientId { get; set; }

    public virtual Documentation Documentation { get; set; } = null!;

    public virtual FollowUpAppointmentRecord FollowUpAppointment { get; set; } = null!;

    public virtual InPatientHistory InPatient { get; set; } = null!;

    public virtual PatientMedicalPlan MedicalPlan { get; set; } = null!;
}
