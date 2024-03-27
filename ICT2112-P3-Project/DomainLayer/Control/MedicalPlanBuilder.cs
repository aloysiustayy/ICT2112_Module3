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
        public List<Prescription> _drugsSelected { get; set; }
        public List<Prescription> _prescriptions { get; set; }

        public MedicalPlanBuilder() { }

        public void SetPrescriptions(List<Prescription> prescription)
        {

            _prescriptions = prescription;
        }

        public void SetSelectedDrugs(List<Prescription> selectedDrugs)
        {
            _drugsSelected = selectedDrugs;
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
            List<Prescription> prescriptions = new List<Prescription>();
            prescriptions.AddRange(_drugsSelected);
            prescriptions.AddRange(_prescriptions);
            Console.WriteLine("Building Medical Plan: " + _medicalPlan.Prescriptions.ElementAt(0).Drug.DrugName);

            return _medicalPlan;
        }

    }
}
