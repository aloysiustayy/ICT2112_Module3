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
    }
}