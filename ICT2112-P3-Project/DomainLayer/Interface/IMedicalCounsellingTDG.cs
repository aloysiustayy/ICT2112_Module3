using System;
using DomainLayer.Entity;
namespace DomainLayer.Interface
{
	public interface IMedicalCounsellingTDG
	{
        public List<MedicationCounselling> RetrieveAllMedicalCounselling();
		public MedicationCounselling GetMedicalCounsellingByPatientId(long patientID);
		//public List<MedicationCounselling> GetMedicalCounsellingsByPatientId(long patientID);
		public void CreateMedicalCounselling(MedicationCounselling newMedicalCounselling);
        //public void UpdateMedicalCounselling(MedicationCounselling existingMedicalCounselling);
        //public void DeleteMedicalCounselling(long patientID);
        public Patient GetPatientById(long patientID);
    }
}

