using DomainLayer.Control;
using DomainLayer.Entity;
using DomainLayer.Interface;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationLayer.Views.ViewModel;
using Newtonsoft.Json;
using System.Buffers.Text;

namespace PresentationLayer.Controllers
{

    public class MedicalPlanController : Controller
    {
        private readonly ILogger<MedicalPlanController> _logger;
        private readonly IMedicalPlanTDG _medicalPlanTDG;
        private readonly IDrugRecordTDG _drugRecordTDG;
        private readonly IDrugTDG _drugTDG;

        private long patientID = 2;


        public MedicalPlanController(ILogger<MedicalPlanController> logger, IMedicalPlanTDG medicalPlanTDG, IDrugRecordTDG drugRecordTDG, IDrugTDG drugTDG, IOCR_API_TDG iOCR_API_TDG)
        {
            _logger = logger;
            _medicalPlanTDG = medicalPlanTDG;
            _drugRecordTDG = drugRecordTDG;
            _drugTDG = drugTDG;
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
        public IActionResult GeneratePlan(MedicationEntryViewModel model)
        {
            // Example of logging the received data
            MedicalPlanBuilder planBuilder = null;
            if (TempData["SelectedDrugs"] is string builderJson)
            {
                // Deserialize the JSON string back into a MedicalPlanBuilder object
                planBuilder = JsonConvert.DeserializeObject<MedicalPlanBuilder>(builderJson);
            }
            List<Prescription> prescriptions = new List<Prescription>();
            for (int i = 0; i < model.MedicationEntries.Count; i++)
            {
                _logger.LogInformation("Medication: {DrugID}, Day: {Day}, TimesPerDay: {TimesPerDay}, BeforeMeals: {BeforeMeals}",
                    model.MedicationEntries[i].DrugID, model.MedicationEntries[i].Day, model.MedicationEntries[i].TimesPerDay, model.MedicationEntries[i].BeforeMeals);
                MedicationTracker tracker = new MedicationTracker().CreateTracker(model.MedicationEntries[i].TimesPerDay, model.MedicationEntries[i].BeforeMeals, model.MedicationEntries[i].Day);
                int drugID = Convert.ToInt32(model.MedicationEntries[i].DrugID);
                DrugManagement dm = new DrugManagement(_drugTDG);
                

                Prescription prescription = new Prescription { DrugId = Convert.ToInt64(model.MedicationEntries[i].DrugID), Drug = dm.retrieveDrug(drugID),  MedicationTracker = tracker };
               prescriptions.Add(prescription);
            }
            planBuilder.SetPrescriptions(prescriptions);

            _logger.LogInformation(planBuilder.ToString());
            TempData["SelectedDrugs"] = JsonConvert.SerializeObject(planBuilder);
            _logger.LogInformation(JsonConvert.SerializeObject(planBuilder));

            return RedirectToAction("Plan");
        }


        public IActionResult ImageUpload()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Plan()
        {
            PatientMedicalPlan plan = null;
            if (TempData["SelectedDrugs"] is string builderJson)
            {
                // Deserialize the JSON string back into a MedicalPlanBuilder object
                MedicalPlanBuilder x = JsonConvert.DeserializeObject<MedicalPlanBuilder>(builderJson);
                _logger.LogInformation((string?)TempData["SelectedDrugs"]);
                plan = x.Build();
                _logger.LogInformation(plan.PatientId.ToString());
            }
            return View(plan);
        }

        public async Task<IActionResult> GeneratePlan()
        {
            DrugManagement dm = new DrugManagement(_drugTDG);
            DrugRecordManagement ac = new DrugRecordManagement(_drugRecordTDG);
            var drugRecordViewModel = new DrugRecordViewModel
            {
                Drugs = dm.retrieveAllDrug(),
                DrugRecordDrug = ac.retrieveDrugRecordDrugs(patientID)
            };
            
            return View(drugRecordViewModel);
        }

        public async Task<IActionResult> SelectDrugRecordDrugs()
        {
            DrugManagement dm = new DrugManagement(_drugTDG);
            DrugRecordManagement ac = new DrugRecordManagement(_drugRecordTDG);
            var test = ac.retrieveDrugRecords(patientID);
            _logger.LogInformation("DrugRecord: {DrugRecord}", test[1].DrugRecordID);


            var drugRecordViewModel = new DrugRecordViewModel
            {
                Drugs = dm.retrieveAllDrug(),
                DrugRecordDrug = ac.retrieveDrugRecordDrugs(patientID),
            };
            return View(drugRecordViewModel);

            // TODO: Continue, either dropdown, choose drugrecord then choose drugs, or just display all drugs combined drugrecord
        }


        [HttpPost]
        public IActionResult SelectDrugRecordDrugs(long[] SelectedDrugs)
        {
            var selectedDrugIds = SelectedDrugs; // This now contains all the selected DrugId values

            // Example of logging the received data
            foreach (var drugId in selectedDrugIds)
            {
                _logger.LogInformation($"Selected Drug ID: {drugId}");
            }
            DrugManagement dm = new DrugManagement(_drugTDG);
            List<Prescription> tracker = new List<Prescription>();
            foreach (var drugId in selectedDrugIds)
            {
                tracker.Add(new Prescription { DrugId = drugId, Drug = dm.retrieveDrug((int)drugId), MedicationTracker = new MedicationTracker() });
            }

            var planBuilder = new MedicalPlanBuilder();
            planBuilder.SetSelectedDrugs(tracker);

            // Serialize the planBuilder object to a JSON string
            var trackerJson = JsonConvert.SerializeObject(planBuilder);
            // Store the JSON string in TempData
            TempData["SelectedDrugs"] = trackerJson;


            return RedirectToAction("GeneratePlan");
        }
    }
}