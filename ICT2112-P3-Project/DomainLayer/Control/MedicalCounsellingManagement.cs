using System;
using DomainLayer.Interface;
using DomainLayer.Entity;
using System.Text;

namespace DomainLayer.Control
{
	public class MedicalCounsellingManagement
	{
		private readonly IMedicalCounsellingTDG _administratorDbContext;

		public MedicalCounsellingManagement(IMedicalCounsellingTDG administratorDbContext)
		{
			_administratorDbContext = administratorDbContext;
		}

		public List<MedicationCounselling> retrieveAllRecord()
		{
			return _administratorDbContext.RetrieveAllMedicalCounselling();
		}

		public MedicationCounselling retrieveMedicalCounselling(long patientID)
		{
			return _administratorDbContext.GetMedicalCounsellingByPatientId(patientID);
		}

        //public List<MedicationCounselling> retrieveMedicalCounsellings(long patientID)
        //{
        //    return _administratorDbContext.GetMedicalCounsellingsByPatientId(patientID);
        //}

        public Patient getPatient(long patientID)
        {
            return _administratorDbContext.GetPatientById(patientID);
        }


		public void createMedicalCounselling(long patientId, string medicalCounsellingChoice, string additionalNotes)
		{

            Console.WriteLine("Patient: "+ getPatient(patientId));

            var patient = getPatient(patientId);

            // Create a new instance of MedicationCounselling
            MedicationCounselling newMedicationCounselling = new MedicationCounselling
            {
                PatientId = patientId,
                // Convert the string to a byte array using ASCII encoding
                MedicationCounsellingChoice = Encoding.ASCII.GetBytes(medicalCounsellingChoice),
                MedicationCounsellingDescription = additionalNotes,
                // Assign the patient to the MedicationCounselling's Patient navigation property
                Patient = patient
            };

            // Output information for debugging
            Console.WriteLine("=====START=====");
            Console.WriteLine("=====INSERTING=====");
            Console.WriteLine("Medical Counselling Choice: " + medicalCounsellingChoice);
            Console.WriteLine("Additional Notes: " + additionalNotes);
            Console.WriteLine("Patient ID: " + patientId);
            Console.WriteLine("=====END=====");

            // Call the method to create the MedicationCounselling record in the database
            _administratorDbContext.CreateMedicalCounselling(newMedicationCounselling);
        }

    }
}

