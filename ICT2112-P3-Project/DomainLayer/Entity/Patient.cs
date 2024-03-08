using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class Patient
{
    public long PatientId { get; set; }

    public string Identifier { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Nric { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public long PhoneNumber { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string PreferredNotificationPlatform { get; set; } = null!;

    public virtual ICollection<InPatientHistory> InPatientHistories { get; set; } = new List<InPatientHistory>();

    public virtual ICollection<MedicationCounselling> MedicationCounsellings { get; set; } = new List<MedicationCounselling>();

    public virtual ICollection<PatientCaregiverAssignment> PatientCaregiverAssignments { get; set; } = new List<PatientCaregiverAssignment>();

    public virtual ICollection<PatientMedicalPlan> PatientMedicalPlans { get; set; } = new List<PatientMedicalPlan>();

    public virtual ICollection<PatientMedicalRecord> PatientMedicalRecords { get; set; } = new List<PatientMedicalRecord>();

    public virtual ICollection<RescheduleRequest> RescheduleRequests { get; set; } = new List<RescheduleRequest>();

    public virtual ICollection<SafetyChecklistAssessment> SafetyChecklistAssessments { get; set; } = new List<SafetyChecklistAssessment>();
}
