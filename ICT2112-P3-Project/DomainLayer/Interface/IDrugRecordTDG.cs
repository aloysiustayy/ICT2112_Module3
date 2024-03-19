using DomainLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface IDrugRecordTDG
    {
        // public DrugRecord GetDrugRecordByPatientId(int patientID);

        public List<DrugRecord> RetrieveAllDrugRecord();
        public DrugRecord GetDrugRecordByPatientId(long patientID);
        public List<DrugRecord> GetDrugRecordsByPatientId(long patientID);
        public void CreateDrugRecord(DrugRecord newDrugRecord);
        public void UpdateDrugRecord(DrugRecord existingDrugRecord);
        public void DeleteDrugRecord(long patientID);
        public DrugRecordDrug GetDrugRecordDrug(long patientID);

        public List<DrugRecordDrug> GetDrugRecordDrugs(long patientID);
    }
}