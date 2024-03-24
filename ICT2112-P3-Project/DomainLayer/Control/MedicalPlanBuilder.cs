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
        public void SetPrescriptions(List<Prescription> prescription)
        {

            _prescriptions = prescription;
        }

        public void SetSelectedDrugs(List<Prescription> selectedDrugs)
        {
            _drugsSelected = selectedDrugs;
        }

        public PatientMedicalPlan Build()
        {
            PatientMedicalPlan p = new PatientMedicalPlan();
            List<Prescription> prescriptions = new List<Prescription>();
            prescriptions.AddRange(_drugsSelected);
            prescriptions.AddRange(_prescriptions);
            p.Prescriptions = prescriptions;
            Console.WriteLine("Building Medical Plan: " + p.Prescriptions.ElementAt(0).Drug.DrugName);
            

            // Add the rest of the properties
            p.PatientId = 2;
            p.PlanStart = DateTime.Now;
            p.PlanEnd = DateTime.Now.AddMonths(1);
            p.PlanNotes = "This is a test plan";
            p.AssignedByNurseId = 1;

            _medicalPlan = p;
            return _medicalPlan;
        }

    }
}
