using DomainLayer.Entity;
using DomainLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Control
{
    public class MedicalPlanManagement : IMedicalPlan
    {
        private readonly IMedicalPlanTDG _medicalPlanTDG;
        public MedicalPlanManagement(IMedicalPlanTDG medicalPlanTDG)
        {
            _medicalPlanTDG = medicalPlanTDG;
        }

        public void GeneratePlan(PatientMedicalPlan medicalPlan)
        {
            throw new NotImplementedException();
        }
        public void AddToPrescription(Drug drug, PatientMedicalPlan medicalPlan, int timesPerDay, bool beforeMeals, string day)
        {
            var existingPrescription = medicalPlan.Prescriptions.FirstOrDefault(p => p.DrugId == drug.DrugId);

            if (existingPrescription == null)
            {
                MedicationTracker tracker = new();
                // If the drug is not in the prescription, create a new tracker and prescription
                var newTracker = tracker.CreateTracker(timesPerDay, beforeMeals, day);
                var newPrescription = new Prescription
                {
                    DrugId = drug.DrugId,
                    MedicationTrackerId = newTracker.TrackingId,
                    PatientMedicalPlanId = medicalPlan.PlanId,
                };
                medicalPlan.Prescriptions.Add(newPrescription);
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
        public string ExecuteOCR(string base64EncodedImage)
        {
            throw new NotImplementedException();
        }

        public void ExportPlan()
        {
            throw new NotImplementedException();
        }
    }
}