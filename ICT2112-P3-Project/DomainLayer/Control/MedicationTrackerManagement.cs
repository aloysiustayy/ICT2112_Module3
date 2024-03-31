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
        public class MedicationTrackerManagement
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

            public async Task CheckForMissedOrIncorrectUploads(int patientId)
            {

                

                var prescriptions = await _prescriptionTDG.GetPrescriptionsByPatientIdAsync(patientId);

                foreach (var prescription in prescriptions)
                {
                    Console.WriteLine("Prescription loop started"); // For debugging
                    


                    var tracker = await _medicationTrackerTDG.GetMedicationTrackerById((int)prescription.MedicationTrackerId);
                    var timesPerDay = tracker.TimesPerDay; // Assume this is how you access the TimesPerDay value.

                    
                    
                    // Define planStart 
                    var planStart = prescription.PatientMedicalPlan.PlanStart;
                    var today = DateTime.Today;
                    var endOfToday = today.AddDays(1);

                    // Fetch consumed dates for this tracker ID
                    var consumedToday = tracker.ConsumedOn
                        .Where(c => c.DateTime >= today && c.DateTime < endOfToday)
                        .ToList();
                    
                    var now = DateTime.Now;

                    if (consumedToday.Any())
                    {

                        Console.WriteLine("Found consumedToday records"); // For debugging
                        var lastUploadDateTime = consumedToday.First();
                        var hoursUntilNextDose = 24 / timesPerDay;
                        var nextDoseTime = lastUploadDateTime.DateTime.AddHours(hoursUntilNextDose);
                        var timeUntilNextDose = nextDoseTime - now;

                        if (timeUntilNextDose.TotalMinutes > 0)
                        {
                            _logger.LogInformation($"Patient {patientId} has successfully uploaded a photo for tracker {tracker.TrackingId}. Next upload should be in {timeUntilNextDose.Hours} hours and {timeUntilNextDose.Minutes} minutes.");
                        }
                    }

                    // Calculate the start of the current day to determine the window for today's uploads. 
                    for (int i = 0; i < timesPerDay; i++)
                    {
                        //Calculate the start and end of the time window for this dose
                        var windowStart = planStart.AddHours(12 * i);
                        var windowEnd = windowStart.AddHours(12);

                        // If we're within the time window for the next dose, we shouldn't check yet.
                        if (now < windowEnd)
                            break;

                        // Check if there's a photo upload within this time window
                        var uploadMade = consumedToday.Any(c => c.DateTime >= windowStart && c.DateTime < windowEnd);

                        Console.WriteLine("Checking upload windows"); // For debugging
                        if (!uploadMade)
                        {
                            // This should print if the conditions are met
                            Console.WriteLine($"Notify Nurse: Patient {patientId} did not upload the correct drug image within the time window for tracker {tracker.TrackingId} between {windowStart} and {windowEnd}.");
                        }
                        else
                        {
                            // Add this else block for debugging purposes
                           
                        }

                    }

                    // Fetch the consumed dates for this tracker that fall within today's window.
                    

                

                }
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
