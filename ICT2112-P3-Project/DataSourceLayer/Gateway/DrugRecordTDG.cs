using DomainLayer.Entity;
using DataSourceLayer.Data;
using DomainLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataSourceLayer.Gateway
{
    public class DrugRecordTDG : IDrugRecordTDG
    {
        private readonly DataContext _context;

        public DrugRecordTDG(DataContext context)
        {
            _context = context;
        }


        // public DrugRecord GetDrugRecordById(int patientId)
        // {
        //     return _context.DrugRecords.Find(patientId);
        // }

        // public void AddDrugRecord(DrugRecord drugRecord)
        // {
        //     _context.DrugRecords.Add(drugRecord);
        // }

        // public void UpdateDrugRecord(DrugRecord drugRecord)
        // {
        //     _context.DrugRecords.Update(drugRecord);
        //     _context.SaveChanges();
        // }

        // public void DeleteDrugRecord(int patientID)
        // {
        //     var existingDrugRecord = _context.DrugRecords.Find(patientID);
        //     if (existingDrugRecord != null)
        //     {
        //         _context.DrugRecords.Remove(existingDrugRecord);
        //         _context.SaveChanges();
        //     }
        // }

        public List<DrugRecord> RetrieveAllDrugRecord()
        {
            return _context.DrugRecords.ToList();
        }
        public DrugRecord GetDrugRecordByPatientId(long patientID)
        {
            return _context.DrugRecords.Find(patientID);
        }
        public List<DrugRecord> GetDrugRecordsByPatientId(long patientID)
        {
            return _context.DrugRecords
                                 //  .Where(drugRecord => drugRecord.PatientID == patientID)
                                 .ToList();
        }


        public void CreateDrugRecord(DrugRecord newDrugRecord)
        {
            // foreach (Drug x in newDrugRecord.Drugs)
            // {
            //     Console.WriteLine("b" + x.DrugName);
            // }
            _context.DrugRecords.Add(newDrugRecord);

            _context.SaveChanges();
        }

        public void UpdateDrugRecord(DrugRecord existingDrugRecord)
        {
            // Attach the entity and mark it as modified if it's not being tracked
            if (!_context.DrugRecords.Local.Any(e => e == existingDrugRecord))
            {
                _context.DrugRecords.Attach(existingDrugRecord);
                _context.Entry(existingDrugRecord).State = EntityState.Modified;
            }

            // No Add needed here since you're updating an existing entity
            _context.SaveChanges();
        }

        public void DeleteDrugRecord(long patientID)
        {
            var existingDrugRecord = _context.DrugRecords.Find(patientID);
            if (existingDrugRecord != null)
            {
                _context.DrugRecords.Remove(existingDrugRecord);
                _context.SaveChanges();
            }
        }

        public DrugRecordDrug GetDrugRecordDrug(long patientID)
        {
            return _context.DrugRecordDrugs.Find(patientID);
        }

        public List<DrugRecordDrug> GetDrugRecordDrugs(long patientID)
        {

            // foreach (DrugRecordDrug x in _context.DrugRecordDrugs
            //                         .Where(drugRecordDrug => drugRecordDrug.PatientID == patientID)
            //                       .ToList())
            // {
            //     Console.WriteLine("TDG is " + x.Drug.DrugName + " | ");
            // }
            // var drugRecordDrugs = _context.DrugRecordDrugs
            //                       .Include(drd => drd.Drug) // Assuming you have a navigation property to Drug
            //                       .Include(drd => drd.DrugRecord) // Assuming you have a navigation property to DrugRecord
            //                       .Where(drd => drd.PatientID == (long)patientID)
            //                       .ToList();

            // foreach (var drd in drugRecordDrugs)
            // {
            //     Console.WriteLine($"Drug?: {drd.Drug.DrugName}, Description: {drd.DrugRecordDescription}, PatientID: {drd.PatientID}");
            // }

            return _context.DrugRecordDrugs
                                  .Where(drugRecordDrug => drugRecordDrug.PatientID == (long)patientID)
                                  .ToList();
        }
    }
}
