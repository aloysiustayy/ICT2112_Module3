using DataSourceLayer.Data;
using DomainLayer.Entity;
using DomainLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourceLayer.Gateway
{
    public class MedicationTrackerTDG : IMedicationTrackerTDG
    {
        private readonly DataContext _context;
        public Task CreateMedicationTrackerAsync(MedicationTracker newTracker)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMedicationTrackerAsync(int trackerId)
        {
            throw new NotImplementedException();
        }

        public Task<MedicationTracker> GetMedicationTrackerById(int trackerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMedicationTrackerAsync(MedicationTracker existingTracker)
        {
            throw new NotImplementedException();
        }
    }
}