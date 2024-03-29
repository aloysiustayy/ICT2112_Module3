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

                    MedicalPlanManagement planManagement = new MedicalPlanManagement(_medicalPlanTDG, _iOCR_API_TDG);
                    string detectedText = await planManagement.ExecuteOCR(base64String);
                    Console.WriteLine(detectedText);

                    // Comparing detected text with the selected medication tracker
                    PrescriptionManagement prescriptionManagement = new PrescriptionManagement(_prescriptionTDG);
                    var prescription = await prescriptionManagement.GetPrescriptionByTrackerId(selectedPrescriptionId);
                    var drugName = prescription.Drug.DrugName;
                    var trackerId = prescription.MedicationTrackerId;
                    ConsumedDateTimeManagement consumedDateTimeManagement = new ConsumedDateTimeManagement(_consumedDateTimeTDG);
                    if(drugName != null && detectedText.Contains(drugName))
                    {
                        Console.WriteLine($"{drugName} found in the image");
                        await consumedDateTimeManagement.AddConsumedDateTime((int)trackerId);
                    }
                    return RedirectToAction("Index");
                }

                // Redirect or return a view here after successful upload
            }
            return RedirectToAction("Index");
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
            return Json(result);
        }
    }
}
