using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Control;
using DomainLayer.Entity;
using DomainLayer.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentationLayer.Controllers
{
    public class MedicalCounsellingController : Controller
    {
        private readonly ILogger<MedicalCounsellingController> _logger;
        private readonly IMedicalCounsellingTDG _medicalCounsellingTDG;

        private long patientID = 2;

        public MedicalCounsellingController(ILogger<MedicalCounsellingController> logger, IMedicalCounsellingTDG medicalCounsellingTDG)
        {
            _logger = logger;
            _medicalCounsellingTDG = medicalCounsellingTDG;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult BookSession()
        {

            return View("BookSession");
        }

        public IActionResult ViewSessions()
        {

            MedicalCounsellingManagement mc = new MedicalCounsellingManagement(_medicalCounsellingTDG);

            var viewModel = new MedicalCounsellingViewModel
            {
                MedicationCounsellings = mc.RetrieveAllRecord()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult BookSession(string counsellingType, string additionalNotes)
        {
            Console.WriteLine(counsellingType);
            Console.WriteLine(additionalNotes);

            MedicalCounsellingManagement medicalCounsellingManagement = new MedicalCounsellingManagement(_medicalCounsellingTDG);

            medicalCounsellingManagement.CreateMedicalCounselling(patientID, counsellingType, additionalNotes);
            Console.WriteLine("Creating!");

            return RedirectToAction("BookSession");
        }
    }

    internal class MedicalCounsellingViewModel
    {
        public List<MedicationCounselling> MedicationCounsellings { get; set; }
    }
}

