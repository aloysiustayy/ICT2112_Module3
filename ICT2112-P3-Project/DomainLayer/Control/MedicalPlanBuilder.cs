using DomainLayer.Entity;
using DomainLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Control
{
    public class MedicalPlanBuilder : IMedicalPlanBuilder
    {
        public PatientMedicalPlan _medicalPlan { get; set; } = new PatientMedicalPlan();
        public List<Prescription> _drugsSelected { get; set; } = new List<Prescription>();
        public List<Prescription> _prescriptions { get; set; } = new List<Prescription>();

        public MedicalPlanBuilder()
        {
        }

        public void SetPrescriptions(List<Prescription> newPrescriptions)
        {
            // Check if the _medicalPlan.Prescriptions is null, initialize it if it is
            if (_medicalPlan.Prescriptions == null)
            {
                _medicalPlan.Prescriptions = new List<Prescription>();
            }

            // Append new prescriptions to the existing list
            foreach (var prescription in newPrescriptions)
            {
                // Here you might also want to check for duplicates before adding
                _medicalPlan.Prescriptions.Add(prescription);
            }
        }

        public void SetSelectedDrugs(List<Prescription> selectedDrugs)
        {
            // Check if the _medicalPlan.Prescriptions is null, initialize it if it is
            if (_medicalPlan.Prescriptions == null)
            {
                _medicalPlan.Prescriptions = new List<Prescription>();
            }

            // Append new prescriptions to the existing list
            foreach (var drug in selectedDrugs)
            {
                // Here you might also want to check for duplicates before adding
                _medicalPlan.Prescriptions.Add(drug);
            }
        }

        public void SetPlanDetails(bool trackPlan, string notes, DateTime start, DateTime end, long patientId, long assignedByNurseId)
        {
            _medicalPlan.TrackPlan = trackPlan;
            _medicalPlan.PlanNotes = notes;
            _medicalPlan.PlanStart = start;
            _medicalPlan.PlanEnd = end;
            _medicalPlan.PatientId = patientId;
            _medicalPlan.AssignedByNurseId = assignedByNurseId;
        }

        public PatientMedicalPlan Build()
        {
            Console.WriteLine("Building Medical Plan: " + _medicalPlan.Prescriptions.ElementAt(0).Drug.DrugName);

            return _medicalPlan;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"TrackPlan: {_medicalPlan.TrackPlan}");
            sb.AppendLine($"PlanNotes: {_medicalPlan.PlanNotes}");
            sb.AppendLine($"PlanStart: {_medicalPlan.PlanStart}");
            sb.AppendLine($"PlanEnd: {_medicalPlan.PlanEnd}");
            sb.AppendLine($"PatientID: {_medicalPlan.PatientId}");
            sb.AppendLine($"AssignedByNurseID: {_medicalPlan.AssignedByNurseId}");

            sb.AppendLine("Prescriptions:");
            foreach (var prescription in _medicalPlan.Prescriptions)
            {
                sb.AppendLine($"  DrugID: {prescription.DrugId}, MedicationTrackerId: {prescription.MedicationTrackerId}");
            }

            return sb.ToString();
        }
    }
}
