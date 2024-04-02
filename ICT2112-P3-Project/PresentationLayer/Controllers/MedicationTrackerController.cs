using DomainLayer.Control;
using DomainLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PresentationLayer.Controllers
{
    public class MedicationTrackerController : Controller
    {
        private readonly ILogger<MedicationTrackerController> _logger;
        private readonly IMedicalPlanTDG _medicalPlanTDG;
        private readonly IPrescriptionTDG _prescriptionTDG;
        private readonly IOCR_API_TDG _iOCR_API_TDG;
        private readonly IDrugTDG _drugTDG;
        private readonly IConsumedDateTimeTDG _consumedDateTimeTDG;


        public MedicationTrackerController(ILogger<MedicationTrackerController> logger, IMedicalPlanTDG medicalPlanTDG, IOCR_API_TDG iOCR_API_TDG, 
            IPrescriptionTDG prescriptionTDG, IDrugTDG drugTDG, IConsumedDateTimeTDG consumedDateTimeTDG)
        {
            _logger = logger;
            _medicalPlanTDG = medicalPlanTDG;
            _iOCR_API_TDG = iOCR_API_TDG;
            _prescriptionTDG = prescriptionTDG;
            _drugTDG = drugTDG;
            _consumedDateTimeTDG = consumedDateTimeTDG;
        }

        public async Task<IActionResult> Index()
        {
            MedicalPlanManagement planManagement = new MedicalPlanManagement(_medicalPlanTDG);
            var medicalPlans = await planManagement.GetPatientAllMedicalPlan(2);
            ViewBag.MedicalPlans = new SelectList(medicalPlans, "PlanId", "PlanNotes");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitImage(IFormFile imageFile, int selectedPrescriptionId)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Read the uploaded image into a MemoryStream
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);

                    // Ensure the memory stream is at the beginning before reading
                    memoryStream.Position = 0;

                    // Convert the byte array to a Base64 string
                    var imageBytes = memoryStream.ToArray();
                    var base64String = Convert.ToBase64String(imageBytes);

                    MedicalPlanManagement planManagement = new MedicalPlanManagement(_medicalPlanTDG, _iOCR_API_TDG, _consumedDateTimeTDG);
                    string detectedText = await planManagement.ExecuteOCR(base64String);
                    Console.WriteLine(detectedText);

                    await CheckForMissedOrIncorrectUploads(detectedText, selectedPrescriptionId);


                    return Json(new {success = true, detectedText, selectedPrescriptionId });
                }

                // Redirect or return a view here after successful upload
            }
            return Json(new { success = false, errorMessage = "No file uploaded." });
        }


        private async Task CheckForMissedOrIncorrectUploads(string detectedText, int selectedPrescriptionId)
        {
            var prescription = await _prescriptionTDG.GetPrescriptionByTrackerIdAsync(selectedPrescriptionId);
            
            if (prescription == null)
            {
                Console.WriteLine($"Prescription with ID {selectedPrescriptionId} not found");
                return;
            }

            // Add a null check for prescription.PatientMedicalPlan before accessing PlanStart
            if (prescription.PatientMedicalPlan == null)
            {
                Console.WriteLine($"Isaac's function: PatientMedicalPlan for prescription {selectedPrescriptionId} not found.");
                return;
            }

            var drugName = prescription.Drug?.DrugName;

            if (string.IsNullOrWhiteSpace(drugName) || !detectedText.Contains(drugName))
            {
                Console.WriteLine($"Isaac's function: The uploaded image for prescription {selectedPrescriptionId} does not match the prescribed medication: {drugName}. Call notify nurse function");
                return; // Exiting the method if the drug doesn't match.
            }


            // Assuming TimesPerDay and PlanStart are accessible from the prescription or its related entities.
            var timesPerDay = prescription.MedicationTracker.TimesPerDay;
            // find how to properly access PlanStart
            var planStart = prescription.PatientMedicalPlan.PlanStart;

            // Check if the detected text matches the prescribed drug name
            if (!detectedText.Contains(drugName))
            {
                Console.WriteLine($"The uploaded image for prescrtion {selectedPrescriptionId} does not match the prescribed medication: {drugName}.");
                return; // Exiting the method if the drug doesn't match.
            }

            // Checking if upload is within the correct time window based on timesPerDay
            var now = DateTime.Now;
            var hoursSincePlanStart = (now - planStart).TotalHours;
            var windowSize = 24 / timesPerDay;
            var currentWindow = (int)Math.Floor(hoursSincePlanStart / windowSize);
            var windowStart = planStart.AddHours(windowSize * currentWindow);
            var windowEnd = windowStart.AddHours(windowSize);

            if (now < windowStart || now > windowEnd)
            {
                Console.WriteLine($"The upload time for prescription {selectedPrescriptionId} is outside the expected window. Current time: {now}, Expected window {windowStart} to {windowEnd}");

            }
            else
            {
                Console.WriteLine($"Upload for prescription {selectedPrescriptionId} is within the expected window");
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetPrescriptionsForMedicalPlan(int medicalPlanId)
        {
            PrescriptionManagement prescriptionManagement = new PrescriptionManagement(_prescriptionTDG);
            var prescriptions = await prescriptionManagement.GetMedicalPlanAllPrescriptions(medicalPlanId);
            
            var result = prescriptions.Select(p => new {
                PrescriptionId = p.MedicationTrackerId, // or another unique identifier for the dropdown value
                PrescriptionDetails = $"{p.Drug.DrugName}" // Example format
            }).ToList();
            // Shows the prescription ID selected, as well as the prescription details. 
            Console.WriteLine("Isaac testing: " + result.Aggregate("", (current, item) => current + $"PrescriptionId = {item.PrescriptionId}, PrescriptionDetails = {item.PrescriptionDetails}\n"));

            return Json(result);
            
        }

        [HttpPost]
        public async Task ConfirmMedicationName(string detectedText, int selectedPrescriptionId)
        {
            MedicalPlanManagement planManagement = new MedicalPlanManagement(_medicalPlanTDG, _iOCR_API_TDG, _consumedDateTimeTDG);
            // Comparing detected text with the selected medication tracker
            PrescriptionManagement prescriptionManagement = new PrescriptionManagement(_prescriptionTDG);
            var prescription = await prescriptionManagement.GetPrescriptionByTrackerId(selectedPrescriptionId);
            var drugName = prescription.Drug.DrugName;
            var trackerId = prescription.MedicationTrackerId;
            if (drugName != null && detectedText.Contains(drugName))
            {
                Console.WriteLine($"{drugName} found in the image");
                await planManagement.UpdateConsumedTime((int)trackerId);
            }
        }
    }
}
