using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainLayer.Entity;
using DomainLayer.Interface;

namespace DomainLayer.Control
{
    public class DrugRecordManagement
    {
        private readonly IDrugRecordTDG _administratorDbContext;

        public DrugRecordManagement(IDrugRecordTDG administratorDbContext)
        {
            _administratorDbContext = administratorDbContext;
        }
        public List<DrugRecord> retrieveAllRecord()
        {
            return _administratorDbContext.RetrieveAllDrugRecord();
        }
        public DrugRecord retrieveRecord(long patientID)
        {
            return _administratorDbContext.GetDrugRecordByPatientId(patientID);
        }
        public List<DrugRecord> retrieveDrugRecords(long patientID)
        {
            return _administratorDbContext.GetDrugRecordsByPatientId(patientID);

        }
        public DrugRecordDrug retrieveDrugRecordDrug(long patientID)
        {
            return _administratorDbContext.GetDrugRecordDrug(patientID);
        }
        public List<DrugRecordDrug> retrieveDrugRecordDrugs(long patientID)
        {
            return _administratorDbContext.GetDrugRecordDrugs(patientID);
        }
        // Console.WriteLine("Creating...");
        // DrugRecord drugRecord = new DrugRecord { PatientID = patientId };

        // // Initialize the collection if it's null
        // drugRecord.DrugRecordDrugs ??= new HashSet<DrugRecordDrug>();

        // foreach (var drug in drugs)
        // {
        //     drugRecord.DrugRecordDrugs.Add(new DrugRecordDrug { Drug = drug });
        // }
        // Console.WriteLine("Adding...");
        // _administratorDbContext.CreateDrugRecord(drugRecord);
        // Console.WriteLine("Added!");
        public void createDrugRecord(long patientId, List<KeyValuePair<Drug, string>> newRecord)
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
            _administratorDbContext.CreateDrugRecord(newDrugRecord);
        }
        // public void createDrugRecord(long patientId, List<Drug> drugs, List<String> drugs)
        // {
        //     Console.WriteLine("Creating...");
        //     DrugRecord drugRecord = new DrugRecord { PatientID = patientId };

        //     // Initialize the collection if it's null
        //     drugRecord.DrugRecordDrugs ??= new HashSet<DrugRecordDrug>();

        //     foreach (var drug in drugs)
        //     {
        //         drugRecord.DrugRecordDrugs.Add(new DrugRecordDrug { Drug = drug });
        //     }
        //     Console.WriteLine("Adding...");
        //     _administratorDbContext.CreateDrugRecord(drugRecord);
        //     Console.WriteLine("Added!");
        // }
        // public List<Administrator> RetrieveAllAdministrativeAccount()
        // {
        //     return _administratorDbContext.GetAllAdministrators();
        // }


        /*        public void CreateAdministrativeAccount() {
                    Administrator c = new Administrator();
                    c.AdministratorId = 1;
                    c.Identifier = "admin1";
                    c.Password = "password123";
                    c.NRIC = "123456789";
                    c.FullName = "John Doe";
                    c.Nationality = "US";
                    c.PhoneNumber = 1234567890;
                    c.EmailAddress = "admin@example.com";
                    c.PreferredNotificationPlatform = "Email";

                    _administratorDbContext.AddAdministrator(c);
                }*/
    }
}
