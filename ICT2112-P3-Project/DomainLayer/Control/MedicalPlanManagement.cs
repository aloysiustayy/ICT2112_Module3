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
        private readonly IConsumedDateTimeTDG _consumedDateTimeTDG;
        public MedicalPlanManagement(IMedicalPlanTDG medicalPlanTDG)
        {
            _medicalPlanTDG = medicalPlanTDG;
        }
        public MedicalPlanManagement(IMedicalPlanTDG medicalPlanTDG, IOCR_API_TDG oCR_API_TDG, IConsumedDateTimeTDG consumedDateTimeTDG)
        {
            _medicalPlanTDG = medicalPlanTDG;
            _iOCR_API_TDG = oCR_API_TDG;
            _consumedDateTimeTDG = consumedDateTimeTDG;
        }

        public void GeneratePlan(PatientMedicalPlan medicalPlan)
        {
            throw new NotImplementedException();
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

        public async Task<List<PatientMedicalPlan>> GetPatientAllMedicalPlan(int patientId)
        {
            return await _medicalPlanTDG.GetMedicalPlanByPatientIdAsync(patientId);
        }

        public async Task UpdateConsumedTime(int trackerId)
        {
            ConsumedDateTimeManagement consumedDateTimeManagement = new ConsumedDateTimeManagement(_consumedDateTimeTDG);
            await consumedDateTimeManagement.AddConsumedDateTime(trackerId);
        }
    }

    public class PrescriptionManagement
    {
        private readonly IPrescriptionTDG _prescriptionTDG;

        public PrescriptionManagement (IPrescriptionTDG prescriptionTDG)
        {
            _prescriptionTDG = prescriptionTDG;
        }

        public async Task<List<Prescription>> GetMedicalPlanAllPrescriptions(int planId)
        {
            return await _prescriptionTDG.GetPrescriptionsByMedicalPlanIdAsync(planId);
        }

        public async Task<Prescription> GetPrescriptionByTrackerId(int trackerId)
        {
            return await _prescriptionTDG.GetPrescriptionByTrackerIdAsync(trackerId);
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