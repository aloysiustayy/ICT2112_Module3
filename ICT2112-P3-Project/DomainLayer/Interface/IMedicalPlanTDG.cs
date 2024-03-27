using DomainLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface IMedicalPlanTDG
    {
        public Task<PatientMedicalPlan> GetMedicalPlanByIdAsync(int planId);
        public Task CreateMedicalPlanAsync(PatientMedicalPlan newPlan);
        public Task UpdateMedicalPlanAsync(PatientMedicalPlan existingPlan);
        public Task DeleteMedicalPlanAsync(int planId);
    }

    public interface IPrescriptionTDG
    {
        public Task<Prescription> GetPrescriptionByIdsAsync(long medicalPlanId, long medicationTrackerId, long drugId);
        public Task CreatePrescriptionAsync(Prescription prescription);
        public Task UpdatePrescriptionAsync(Prescription existingPrescription);
        public Task DeletePrescriptionAsync(long medicalPlanId, long medicationTrackerId, long drugId);
    }
}