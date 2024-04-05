using DomainLayer.Control;
using DomainLayer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class SafetyChecklistInputController : Controller
    {
        private readonly SafetyChecklistControl _safetyChecklistControl;

        public SafetyChecklistInputController(SafetyChecklistControl safetyChecklistControl)
        {
            _safetyChecklistControl = safetyChecklistControl;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewSafetyChecklist()
        {
            var safetyChecklists = _safetyChecklistControl.GetAllSafetyChecklists();
            return View(safetyChecklists);
        }

        [HttpPost]
        public IActionResult UploadSafetyChecklist(SafetyChecklist safetyChecklist)
        {
            _safetyChecklistControl.CreateSafetyChecklist(safetyChecklist);
            return RedirectToAction("ViewSafetyChecklist");
        }

        [HttpPost]
        public IActionResult UpdateSafetyChecklist(SafetyChecklist safetyChecklist)
        {
            _safetyChecklistControl.UpdateSafetyChecklist(safetyChecklist);
            return RedirectToAction("ViewSafetyChecklist");
        }

        [HttpPost]
        public IActionResult DeleteSafetyChecklist(int id)
        {
            _safetyChecklistControl.DeleteSafetyChecklist(id);
            return RedirectToAction("ViewSafetyChecklist");
        }
    }
}
