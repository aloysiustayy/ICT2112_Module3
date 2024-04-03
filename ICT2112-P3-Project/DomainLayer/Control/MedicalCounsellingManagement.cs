using System;
using DomainLayer.Interface;
using DomainLayer.Entity;
using System.Text;

namespace DomainLayer.Control
{
    public class MedicalCounsellingManagement : IMedicalCounselling
    {
        private readonly IMedicalCounsellingTDG _medicalCounsellingDbContext;

        public MedicalCounsellingManagement(IMedicalCounsellingTDG medicalCounsellingDbContext)
        {
            _medicalCounsellingDbContext = medicalCounsellingDbContext;
        }

        public List<MedicationCounselling> RetrieveAllRecord()
        {
            return _medicalCounsellingDbContext.RetrieveAllMedicalCounselling();
        }

        public Patient GetPatient(long patientID)
        {
            return _medicalCounsellingDbContext.GetPatientById(patientID);
        }


        public void CreateMedicalCounselling(long patientID, string medicalCounsellingChoice, string additionalNotes)
        {

            Console.WriteLine("Patient: " + GetPatient(patientID));

            var patient = GetPatient(patientID);

            // Create a new instance of MedicationCounselling
            MedicationCounselling newMedicationCounselling = new MedicationCounselling
            {
                PatientId = patientID,
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
            Console.WriteLine("Patient ID: " + patientID);
            Console.WriteLine("=====END=====");

            // Call the method to create the MedicationCounselling record in the database
            _medicalCounsellingDbContext.CreateMedicalCounselling(newMedicationCounselling);
        }

    }
}

