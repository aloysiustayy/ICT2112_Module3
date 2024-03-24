using DomainLayer.Entity;
using DataSourceLayer.Data;
using DomainLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataSourceLayer.Gateway
{
    public class DrugTDG : IDrugTDG
    {
        private readonly DataContext _context;

        public DrugTDG(DataContext context)
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


        public List<Drug> GetAllDrugs()
        {
            return _context.Drugs.ToList();
        }
        public Drug GetDrugByDrugId(long drugID)
        {
            long id = (long)drugID;
            Drug x = _context.Drugs.Find((long)drugID);
            Console.WriteLine("DrugTDG: " + drugID + "," + x);
            return _context.Drugs.Find(id);
        }

        public void CreateDrug(Drug newDrug)
        {
            _context.Drugs.Add(newDrug);
            _context.SaveChanges();

        }

        public void UpdateDrug(Drug existingDrug)
        {
            // Attach the entity and mark it as modified if it's not being tracked
            if (!_context.Drugs.Local.Any(e => e == existingDrug))
            {
                _context.Drugs.Attach(existingDrug);
                _context.Entry(existingDrug).State = EntityState.Modified;
            }

            // No Add needed here since you're updating an existing entity
            _context.SaveChanges();
        }

        public void DeleteDrug(long drugID)
        {
            var existingDrug = _context.Drugs.Find(drugID);
            if (existingDrug != null)
            {
                _context.Drugs.Remove(existingDrug);
                _context.SaveChanges();
            }
        }
    }
}
