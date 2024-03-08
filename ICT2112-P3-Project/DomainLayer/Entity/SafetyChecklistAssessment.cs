using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class SafetyChecklistAssessment
{
    public long AssessmentId { get; set; }

    public byte[] PatientHomeEnvPhotos { get; set; } = null!;

    public string RiskRating { get; set; } = null!;

    public string RiskDescription { get; set; } = null!;

    public long PatientCaregiverId { get; set; }

    public long PatientId { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual PatientCaregiver PatientCaregiver { get; set; } = null!;
}
