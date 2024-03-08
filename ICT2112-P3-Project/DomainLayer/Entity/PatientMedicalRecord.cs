using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class PatientMedicalRecord
{
    public long MedicalRecordId { get; set; }

    public string MedicationCurrent { get; set; } = null!;

    public string MedicationPast { get; set; } = null!;

    public string DiagnosisCurrent { get; set; } = null!;

    public string DiagnosisPast { get; set; } = null!;

    public string ImmunizationStatus { get; set; } = null!;

    public string Allergies { get; set; } = null!;

    public byte[] Erratum { get; set; } = null!;

    public string HealthImprovementProgress { get; set; } = null!;

    public string IllnessName { get; set; } = null!;

    public long PatientId { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
