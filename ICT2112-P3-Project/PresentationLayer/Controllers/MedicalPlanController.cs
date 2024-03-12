using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class MedicalPlanController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> SubmitImage(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Step 1: Read the uploaded image into a MemoryStream
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);

                    // Ensure the memory stream is at the beginning before reading
                    memoryStream.Position = 0;

                    // Step 2: Convert the byte array to a Base64 string
                    var imageBytes = memoryStream.ToArray();
                    var base64String = Convert.ToBase64String(imageBytes);

                    // Now you have the image as a Base64 string
                    // You can pass this string to your view, store it, or perform further actions

                    // For demonstration, let's just return it to the view
                    ViewBag.Base64String = base64String;
                    return View();
                }

                // Redirect or return a view here after successful upload
            }
            return View();
        }
        public IActionResult ImageUpload()
        {
            return View();
        }
    }
}