using DomainLayer.Control;
using DomainLayer.Entity;
using DomainLayer.Interface;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Buffers.Text;

namespace PresentationLayer.Controllers
{
    public class MedicalPlanController : Controller
    {
        private readonly ILogger<MedicalPlanController> _logger;
        private readonly IMedicalPlanTDG _medicalPlanTDG;
        private readonly IOCR_API_TDG _iOCR_API_TDG;

        public MedicalPlanController(ILogger<MedicalPlanController> logger, IMedicalPlanTDG medicalPlanTDG, IOCR_API_TDG iOCR_API_TDG)
        {
            _logger = logger;
            _medicalPlanTDG = medicalPlanTDG;
            _iOCR_API_TDG = iOCR_API_TDG;
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

                    MedicalPlanManagement planManagement = new MedicalPlanManagement(_medicalPlanTDG, _iOCR_API_TDG);
                    string test = await planManagement.ExecuteOCR(base64String);
                    Console.WriteLine(test);
                    return RedirectToAction("ImageUpload");
                }

                // Redirect or return a view here after successful upload
            }
            return RedirectToAction("ImageUpload");
        }

        [HttpPost]
        public IActionResult GeneratePlan(long planId)
        {
            // Here, you'd use the planId to generate a plan
            // This is a placeholder for your existing logic
            // For now, we'll just redirect to the Index view as a placeholder
            MedicalPlanManagement medicalPlanManagement = new MedicalPlanManagement(_medicalPlanTDG);
            Console.WriteLine("Generating plan for planId: " + planId);
            _logger.LogInformation("Generating plan for plan ID {PlanId}", planId);
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

        public IActionResult GeneratePlan()
        {
            // Simply returns the view with the form
            return View();
        }

    }
}