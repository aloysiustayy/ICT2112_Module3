using DomainLayer.Control;
using DomainLayer.Entity;
using Microsoft.AspNetCore.Mvc;


namespace PresentationLayer.Controllers
{
    public class UploadPhotoInputController : Controller
    {
        private readonly PhotoControl _photoControl;
        private readonly SafetyChecklistControl _safetyChecklistControl;

        public UploadPhotoInputController(PhotoControl photoControl, SafetyChecklistControl safetyChecklistControl)
        {
            _photoControl = photoControl;
            _safetyChecklistControl = safetyChecklistControl;
        }

        public IActionResult SafetyChecklist()
        {
            return View("~/Views/Home/SafetyChecklist.cshtml");
        }

        [HttpPost]
        public IActionResult AddPhoto(string imageURLInput)
        {
          


            byte[] photoBytes = Convert.FromBase64String(imageURLInput.Split(',')[1]);

            // Create and save the new Photo
            var newPhoto = new Photo
            {
                PhotoImage = photoBytes
            };
            _photoControl.AddPhoto(newPhoto);

            // Create the new SafetyChecklist, insert dummy data
            var newSafetyChecklist = new SafetyChecklist
            {
                LocationCategory = "dummy",
                RiskTitle = "dummy",
                RiskComment = "dummy",
                RiskDescription = "dummy",
                PhotoId = newPhoto.PhotoId 

            };

            // Assuming you have a similar control for SafetyChecklist
            _safetyChecklistControl.AddSafetyChecklist(newSafetyChecklist);

            // Redirect to the SafetyChecklist view
            return RedirectToAction("SafetyChecklist");
        }
    }
}
