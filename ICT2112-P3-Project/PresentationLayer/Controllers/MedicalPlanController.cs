using DomainLayer.Control;
using DomainLayer.Entity;
using DomainLayer.Interface;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Views.ViewModel;
using System.Buffers.Text;

namespace PresentationLayer.Controllers
{




    public class MedicalPlanController : Controller
    {
        private readonly ILogger<MedicalPlanController> _logger;
        private readonly IMedicalPlanTDG _medicalPlanTDG;

        public MedicalPlanController(ILogger<MedicalPlanController> logger, IMedicalPlanTDG medicalPlanTDG)
        {
            _logger = logger;
            _medicalPlanTDG = medicalPlanTDG;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitImage(IFormFile imageFile)
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

                    // Now you have the image as a Base64 string
                    // You can pass this string to your view, store it, or perform further actions

                    // MedicalPlanManagement planManagement = new MedicalPlanManagement();
                    // planManagement.ExecuteOCR(base64String);
                    return View();
                }

                // Redirect or return a view here after successful upload
            }
            return View();
        }

        [HttpPost]
        public IActionResult GeneratePlan(MedicationViewModel model)
        {
            // Example of logging the received data
            for (int i = 0; i < model.SelectedMedicationNames.Count; i++)
            {
                _logger.LogInformation("Medication: {MedicationName}, Dosage: {Dosage}",
                    model.SelectedMedicationNames[i], model.Dosage[i]);
            }

            // Additional processing here

            return RedirectToAction("Index");
        }


        public IActionResult ImageUpload()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GeneratePlan()
        {

            //  var medications = await _medicalPlanTDG.GetMedicationsAsync();

            // Simulating an asynchronous operation to fetch medications
            var medicationOptions = await Task.FromResult(new List<MedicationOption>
            {
                new MedicationOption { Name = "Acetaminophen", Value = "1" },
                new MedicationOption { Name = "Ibuprofen", Value = "2" },
                new MedicationOption { Name = "Amoxicillin", Value = "3" },
                new MedicationOption { Name = "Ciprofloxacin", Value = "4" },
                new MedicationOption { Name = "Clindamycin", Value = "5" }
                // Add more sample medications as needed
            });
            var viewModel = new MedicationPlanViewModel
            {
                MedicationOptions = medicationOptions,
                WeeklyPlan = new Dictionary<string, List<MedicationTask>>
                {
                          { "Sunday", new List<MedicationTask> { new MedicationTask { MedicationName = "Acetaminophen", Dosage = "500mg", Times = new List<string> { "08:00 AM", "08:00 PM" } } } },

                }
            };

            return View(viewModel);
        }


        public IActionResult WeeklyMedicationPlan()
        {
            var viewModel = new WeeklyMedicationPlanViewModel
            {
                WeeklyPlan = new Dictionary<string, List<MedicationTask>>
        {
            { "Sunday", new List<MedicationTask> { new MedicationTask { MedicationName = "Acetaminophen", Dosage = "500mg", Times = new List<string> { "08:00 AM", "08:00 PM" } } } },
            // Add entries for other days of the week...
        }
            };

            return View(viewModel);
        }
    }
}