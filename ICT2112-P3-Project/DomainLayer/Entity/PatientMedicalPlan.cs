using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entity;

public partial class PatientMedicalPlan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long PlanId { get; set; }
    public long PatientId { get; set; }
    public string PlanNotes { get; set; } = null!;
    public DateTime PlanStart { get; set; }
    public DateTime PlanEnd { get; set; }
    public bool TrackPlan { get; set; }
    public long AssignedByNurseId { get; set; }
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    public virtual ICollection<DischargeRecord> DischargeRecords { get; set; } = new List<DischargeRecord>();
    public virtual Patient Patient { get; set; } = null!;
}