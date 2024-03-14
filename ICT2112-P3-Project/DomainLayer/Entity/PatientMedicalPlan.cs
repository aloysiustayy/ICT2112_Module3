using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class PatientMedicalPlan
{
    public long PlanId { get; set; }
    public long AccountId { get; set; }
    public long PatientId { get; set; }
    public string PlanNotes { get; set; } = null!;
    public DateTime PlanStart { get; set; }
    public DateTime PlanEnd { get; set; }
    public bool TrackPlan { get; set; }
    public long AssignedByNurseId { get; set; }
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    public virtual ICollection<DischargeRecord> DischargeRecords { get; set; } = new List<DischargeRecord>();
    public virtual Patient Patient { get; set; } = null!;

    public static MedicationTracker CreateTracking(int timesPerDay, bool beforeMeals, string day)
    {
        var newTracker = new MedicationTracker
        {
            TimesPerDay = timesPerDay,
            BeforeMeals = beforeMeals,
            Day = day
        };
        return newTracker;
    }

    public void AddToPrescription(Drug drug, long planId, int timesPerDay, bool beforeMeals, string day)
    {
        // Assuming that the Drug entity has an ID property
        var existingPrescription = Prescriptions.FirstOrDefault(p => p.DrugId == drug.DrugId);

        if (existingPrescription == null)
        {
            // If the drug is not in the prescription, create a new tracker and prescription
            var newTracker = CreateTracking(timesPerDay, beforeMeals, day);
            var newPrescription = new Prescription
            {
                DrugId = drug.DrugId,
                MedicationTrackerId = newTracker.TrackingId,
                PatientMedicalPlanId = planId,
            };
            Prescriptions.Add(newPrescription);
        }
        else
        {
            // If the drug is already in the prescription, update the existing tracker
            var existingTracker = existingPrescription.MedicationTracker;
            existingTracker.TimesPerDay = timesPerDay;
            existingTracker.BeforeMeals = beforeMeals;
            existingTracker.Day = day;
        }
    }
}