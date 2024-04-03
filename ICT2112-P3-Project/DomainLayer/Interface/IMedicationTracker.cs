using DomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface IMedicationTracker
    {
        public Task<MedicationTracker> GetMedicationTracker(int trackerID);
        public Task<MedicationTracker> CreateMedicationTracker(int timesPerDay, bool beforeMeals);


        public void DeleteMedicationTrackerById(int trackerId);

        public void UpdateMedicationTracker(MedicationTracker existingTracker);
    }


}