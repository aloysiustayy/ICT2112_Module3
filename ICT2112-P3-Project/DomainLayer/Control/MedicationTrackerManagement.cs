using DomainLayer.Entity;
using DomainLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Logging;

namespace DomainLayer.Control
{
    public class MedicationTrackerManagement : IMedicationTracker
    {
        private readonly IMedicationTrackerTDG _medicationTrackerTDG;

        private readonly IPrescriptionTDG _prescriptionTDG;
        private readonly IConsumedDateTimeTDG _consumedDateTimeTDG;

        private readonly ILogger<MedicationTrackerManagement> _logger;



        public MedicationTrackerManagement(IMedicationTrackerTDG medicationTrackerTDG, IPrescriptionTDG prescriptionTDG, IConsumedDateTimeTDG consumedDateTimeTDG, ILogger<MedicationTrackerManagement> logger)
        {
            _medicationTrackerTDG = medicationTrackerTDG;
            _prescriptionTDG = prescriptionTDG;
            _consumedDateTimeTDG = consumedDateTimeTDG;
            _logger = logger; // Initialize logger
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

    public class ConsumedDateTimeManagement
    {
        private readonly IConsumedDateTimeTDG _consumedDateTimeTDG;

        public ConsumedDateTimeManagement(IConsumedDateTimeTDG consumedDateTimeTDG)
        {
            _consumedDateTimeTDG = consumedDateTimeTDG;
        }

        public async Task AddConsumedDateTime(int trackerId)
        {
            var dateTimeNow = DateTime.Now;
            await _consumedDateTimeTDG.CreateConsumedDateTime(trackerId, dateTimeNow);
        }
    }
}
