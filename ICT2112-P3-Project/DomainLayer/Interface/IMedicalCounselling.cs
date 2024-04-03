using System;
using DomainLayer.Entity;
namespace DomainLayer.Interface
{
    public interface IMedicalCounselling
    {
        public List<MedicationCounselling> RetrieveAllRecord();

        public Patient GetPatient(long patientID);

        public void CreateMedicalCounselling(long patientID, string medicalCounsellingChoice, string additionalNotes);
    }
}

