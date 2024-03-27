using DomainLayer.Entity;
using DomainLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Control
{
    public class MedicationTrackerManagement
    {
        private readonly IMedicationTrackerTDG _medicationTrackerTDG;

        public MedicationTrackerManagement(IMedicationTrackerTDG medicationTrackerTDG)
        {
            _medicationTrackerTDG = medicationTrackerTDG;
        }

        public async Task<MedicationTracker> GetMedicationTracker(int trackerID) 
        {
            return await _medicationTrackerTDG.GetMedicationTrackerById(trackerID);
        }

        public async Task<MedicationTracker> CreateMedicationTracker(int timesPerDay, bool beforeMeals)
        {
            var trackerEntity = new MedicationTracker();
            var newTracker = trackerEntity.CreateTracker(timesPerDay, beforeMeals);
            await _medicationTrackerTDG.CreateMedicationTrackerAsync(newTracker);
            return newTracker;
        }

        public async void DeleteMedicationTrackerById(int trackerId)
        {
            await _medicationTrackerTDG.DeleteMedicationTrackerAsync(trackerId);
        }

        public async void UpdateMedicationTracker(MedicationTracker existingTracker)
        {
            await _medicationTrackerTDG.UpdateMedicationTrackerAsync(existingTracker);
        }
    }
}
