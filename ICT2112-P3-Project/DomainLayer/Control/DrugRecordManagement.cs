using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainLayer.Entity;
using DomainLayer.Interface;

namespace DomainLayer.Control
{
    public class DrugRecordManagement : IDrugRecord
    {
        private readonly IDrugRecordTDG _drugRecordDbContext;

        public DrugRecordManagement(IDrugRecordTDG drugRecordDbContext)
        {
            _drugRecordDbContext = drugRecordDbContext;
        }

        public void CreateDrugRecord(long patientId, List<KeyValuePair<Drug, string>> newRecord)
        {
            DrugRecord newDrugRecord = new DrugRecord { PatientID = patientId };

            // Initialize the collection if it's null
            newDrugRecord.DrugRecordDrugs ??= new HashSet<DrugRecordDrug>();


            foreach (var record in newRecord)
            {
                DrugRecordDrug temp = new DrugRecordDrug
                {
                    Drug = record.Key,
                    DrugRecordDescription = record.Value,
                    PatientID = patientId
                };

                newDrugRecord.DrugRecordDrugs.Add(temp);
            }

            Console.WriteLine("=====START=====");
            foreach (var xc in newDrugRecord.DrugRecordDrugs)
            {
                Console.WriteLine("=====INSERTING=====");
                Console.WriteLine("Patient ID: " + xc.PatientID);
                Console.WriteLine("DrugId: " + xc.Drug.DrugId);
                Console.WriteLine("DrugName: " + xc.Drug.DrugName);
                Console.WriteLine("DrugRecordDescription: " + xc.DrugRecordDescription);
                Console.WriteLine("=====DONE=====");
            }
            Console.WriteLine("=====END=====");
            _drugRecordDbContext.CreateDrugRecord(newDrugRecord);
        }

        public List<DrugRecordDrug> RetrieveDrugRecordDrugs(long patientID)
        {
            return _drugRecordDbContext.GetDrugRecordDrugs(patientID);
        }

        public void UpdateRecord(long patientID, List<KeyValuePair<Drug, string>> newRecord)
        {
            DeleteRecord(patientID);
            CreateDrugRecord(patientID, newRecord);
        }

        public void DeleteRecord(long patientID)
        {
            _drugRecordDbContext.DeleteDrugRecord(patientID);
        }
    }
}
