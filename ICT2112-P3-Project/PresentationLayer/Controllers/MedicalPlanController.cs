using DomainLayer.Control;
using DomainLayer.Entity;
using DomainLayer.Interface;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationLayer.Views.ViewModel;
using Newtonsoft.Json;
using System.Buffers.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;
using DataSourceLayer.Gateway;

namespace PresentationLayer.Controllers
{

    public class MedicalPlanController : Controller
    {
        private readonly ILogger<MedicalPlanController> _logger;
        private readonly IMedicalPlanTDG _medicalPlanTDG;
        private readonly IMedicationTrackerTDG _medicationTrackerTDG;
        private readonly IPrescriptionTDG _prescriptionTDG;
        private readonly IDrugRecordTDG _drugRecordTDG;
        private readonly IDrugTDG _drugTDG;
        private readonly IOCR_API_TDG _iOCR_API_TDG;

        private long patientID = 2;


        public MedicalPlanController(ILogger<MedicalPlanController> logger, IMedicalPlanTDG medicalPlanTDG, IDrugRecordTDG drugRecordTDG, IDrugTDG drugTDG, 
            IOCR_API_TDG iOCR_API_TDG, IMedicationTrackerTDG medicationTrackerTDG, IPrescriptionTDG prescriptionTDG)
        {
            _logger = logger;
            _medicalPlanTDG = medicalPlanTDG;
            _drugRecordTDG = drugRecordTDG;
            _drugTDG = drugTDG;
            _iOCR_API_TDG = iOCR_API_TDG;
            _medicationTrackerTDG = medicationTrackerTDG;
            _prescriptionTDG = prescriptionTDG;
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
        public async Task<IActionResult> GeneratePlan(MedicationEntryViewModel model)
        {
            // Example of logging the received data
            MedicalPlanBuilder planBuilder = new MedicalPlanBuilder();
            if (TempData["SelectedDrugs"] is string builderJson)
            {
                // Deserialize the JSON string back into a MedicalPlanBuilder object
                planBuilder = JsonConvert.DeserializeObject<MedicalPlanBuilder>(builderJson);
            }
            planBuilder.SetPlanDetails(model.TrackPlan, model.PlanNotes, model.PlanStart, model.PlanEnd, model.PatientID, model.AssignedByNurseID);

            MedicalPlanManagement medicalPlanManagement = new MedicalPlanManagement(_medicalPlanTDG);
            DrugManagement dm = new DrugManagement(_drugTDG);

            // Create a new plan for creation of prescription
            var newPlan = await medicalPlanManagement.CreateMedicalPlan(model.PatientID, model.PlanNotes, model.PlanStart, model.PlanEnd, model.TrackPlan, model.AssignedByNurseID);
            var planId = newPlan.PlanId;

            List<Prescription> prescriptions = new List<Prescription>();
            if (model.TrackPlan == true)
            {
                // Instantiate the two control classes
                MedicationTrackerManagement medicationTrackerManagement = new MedicationTrackerManagement(_medicationTrackerTDG);
                PrescriptionManagement prescriptionManagement = new PrescriptionManagement(_prescriptionTDG);
                for (int i = 0; i < model.MedicationEntries.Count; i++)
                {
                    _logger.LogInformation("Medication: {DrugID}, TimesPerDay: {TimesPerDay}, BeforeMeals: {BeforeMeals}",
                        model.MedicationEntries[i].DrugID, model.MedicationEntries[i].TimesPerDay, model.MedicationEntries[i].BeforeMeals);
                    
                    var newTracker = await medicationTrackerManagement.CreateMedicationTracker(model.MedicationEntries[i].TimesPerDay, model.MedicationEntries[i].BeforeMeals);
                    var trackerId = newTracker.TrackingId;

                    int drugID = Convert.ToInt32(model.MedicationEntries[i].DrugID);

                    var prescription = await prescriptionManagement.CreatePrescription(planId, trackerId, drugID);
                    prescription.Drug = dm.retrieveDrug(drugID);
                    prescriptions.Add(prescription);
                }
                planBuilder.SetPrescriptions(prescriptions);
                // print the content of planBuilder here 
                var builderContent = planBuilder.ToString();
                _logger.LogInformation(builderContent);
                Console.WriteLine(builderContent);

                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                TempData["SelectedDrugs"] = JsonConvert.SerializeObject(planBuilder, settings);
            }

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
            // MedicalPlanManagement medicalPlanManagement = new MedicalPlanManagement(_medicalPlanTDG);
            if (TempData["SelectedDrugs"] is string builderJson)
            {
                // Deserialize the JSON string back into a MedicalPlanBuilder object
                MedicalPlanBuilder x = JsonConvert.DeserializeObject<MedicalPlanBuilder>(builderJson);
                _logger.LogInformation((string?)TempData["SelectedDrugs"]);
                plan = x.Build();
                // medicalPlanManagement.CreateMedicalPlan(plan);
                // _logger.LogInformation(plan.PatientId.ToString());
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