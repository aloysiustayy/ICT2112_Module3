using System;
using DomainLayer.Entity;
using DataSourceLayer.Data;
using DomainLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataSourceLayer.Gateway
{
	public class MedicalCounsellingTDG : IMedicalCounsellingTDG
	{
		private readonly DataContext _context;

		public MedicalCounsellingTDG(DataContext context)
		{
			_context = context;
		}

		public List<MedicationCounselling> RetrieveAllMedicalCounselling()
		{
			return _context.MedicationCounsellings.ToList();
		}

		public MedicationCounselling GetMedicalCounsellingByPatientId(long patientID)
		{
			return _context.MedicationCounsellings.Find(patientID);
		}

        //public List<DrugRecord> GetMedicalCounsellingsByPatientId(long patientId)
        //{
        //	return _context.MedicationCounsellings.ToList();
        //}
        public Patient GetPatientById(long patientID)
        {
            RetrieveAllPatients();
			var patient = _context.Patients.Find(patientID);
            if (patient == null)
            {
                Console.WriteLine($"Patient with ID {patientID} not found.");
            }
            else
            {
                Console.WriteLine($"Found patient: {patient.PatientId}");
            }
            return _context.Patients.Find(patientID);
        }

		public List<Patient> RetrieveAllPatients()
		{
            List<Patient> patients = _context.Patients.ToList();

            // Print the details of each patient
            foreach (var patient in patients)
            {
                Console.WriteLine($"Patient ID: {patient.PatientId}");
                Console.WriteLine($"Patient Name: {patient.FullName}");
                // Print other properties as needed
                Console.WriteLine(); // Add a blank line for separation
            }
            return _context.Patients.ToList();
		}

        public void CreateMedicalCounselling(MedicationCounselling newMedicationCounselling)
		{
			_context.MedicationCounsellings.Add(newMedicationCounselling);

			_context.SaveChanges();
		}

		
	}
}

