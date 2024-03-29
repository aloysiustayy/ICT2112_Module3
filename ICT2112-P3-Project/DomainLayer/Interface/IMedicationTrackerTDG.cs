using DomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface IMedicationTrackerTDG
    {
        public Task<MedicationTracker> GetMedicationTrackerById(int trackerId);
        public Task CreateMedicationTrackerAsync(MedicationTracker newTracker);
        public Task UpdateMedicationTrackerAsync(MedicationTracker existingTracker);
        public Task DeleteMedicationTrackerAsync(int trackerId);
    }

    public interface IConsumedDateTimeTDG
    {
        public Task<List<ConsumedDateTime>> GetConsumedDateTimeAsync(int trackerId);
        public Task CreateConsumedDateTime(long trackerId, DateTime dateTime);
    }
}