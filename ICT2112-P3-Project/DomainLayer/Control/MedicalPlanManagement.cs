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
        private readonly IOCR_API_TDG _iOCR_API_TDG;
        public MedicalPlanManagement(IMedicalPlanTDG medicalPlanTDG)
        {
            _medicalPlanTDG = medicalPlanTDG;
        }
        public MedicalPlanManagement(IMedicalPlanTDG medicalPlanTDG, IOCR_API_TDG oCR_API_TDG)
        {
            _medicalPlanTDG = medicalPlanTDG;
            _iOCR_API_TDG = oCR_API_TDG;
        }

        public void GeneratePlan(PatientMedicalPlan medicalPlan)
        {
            throw new NotImplementedException();
        }
        public void AddToPrescription(Drug drug, PatientMedicalPlan medicalPlan, int timesPerDay, bool beforeMeals)
        {
            var existingPrescription = medicalPlan.Prescriptions.FirstOrDefault(p => p.DrugId == drug.DrugId);

            if (existingPrescription == null)
            {
                MedicationTracker tracker = new();
                // If the drug is not in the prescription, create a new tracker and prescription
                var newTracker = tracker.CreateTracker(timesPerDay, beforeMeals);
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
            }
        }
        public async Task<string> ExecuteOCR(string base64EncodedImage)
        {
            var ocrResult = await _iOCR_API_TDG.DetectText(base64EncodedImage);
            return ocrResult;
        }

        public void ExportPlan()
        {
            throw new NotImplementedException();
        }

        public async Task<long> CreateEmptyMedicalPlanAsync()
        {
            var newPlan = new PatientMedicalPlan
            {
                PlanNotes = "",
                PlanStart = DateTime.Now,
                PlanEnd = DateTime.Now
            };
            await _medicalPlanTDG.CreateMedicalPlanAsync(newPlan);
            return newPlan.PlanId;
        }

        public async Task<PatientMedicalPlan> CreateMedicalPlan(long patientId, string planNotes, DateTime planStart, DateTime planEnd, bool trackPlan, long assignedByNurseID) 
        {
            var newPlan = new PatientMedicalPlan
            {
                PatientId = patientId,
                PlanNotes = planNotes,
                PlanStart = planStart,
                PlanEnd = planEnd,
                TrackPlan = trackPlan,
                AssignedByNurseId = assignedByNurseID
            };
            await _medicalPlanTDG.CreateMedicalPlanAsync(newPlan);
            return newPlan;
        }

        public void UpdateMedicalPlan(PatientMedicalPlan existingPlan)
        {
            _medicalPlanTDG.UpdateMedicalPlanAsync(existingPlan);
        }
    }

    public class PrescriptionManagement
    {
        private readonly IPrescriptionTDG _prescriptionTDG;

        public PrescriptionManagement (IPrescriptionTDG prescriptionTDG)
        {
            _prescriptionTDG = prescriptionTDG;
        }

        public async Task<Prescription> CreatePrescription (long medicalPlanId, long medicationTrackerId, long drugId)
        {
            var newPrescription = new Prescription
            {
                PatientMedicalPlanId = medicalPlanId,
                MedicationTrackerId = medicationTrackerId,
                DrugId = drugId
            };
            await _prescriptionTDG.CreatePrescriptionAsync(newPrescription);
            return newPrescription;
        }
    }
}