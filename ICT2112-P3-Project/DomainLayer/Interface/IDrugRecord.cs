using DomainLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface IDrugRecord
    {

        public void CreateDrugRecord(long patientId, List<KeyValuePair<Drug, string>> newRecord);
        public List<DrugRecordDrug> RetrieveDrugRecordDrugs(long patientID);
        public void UpdateRecord(long patientID, List<KeyValuePair<Drug, string>> newRecord);
        public void DeleteRecord(long patientID);
    }
}