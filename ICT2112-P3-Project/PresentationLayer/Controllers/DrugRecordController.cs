using DomainLayer.Control;
using DomainLayer.Entity;
using DomainLayer.Interface;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Buffers.Text;

namespace PresentationLayer.Controllers
{
    public class DrugRecordController : Controller
    {
        private readonly ILogger<DrugRecordController> _logger;
        private readonly IDrugRecordTDG _drugRecordTDG;
        private readonly IDrugTDG _drugTDG;

        public DrugRecordController(ILogger<DrugRecordController> logger, IDrugRecordTDG drugRecordTDG, IDrugTDG drugTDG)
        {
            _logger = logger;
            _drugRecordTDG = drugRecordTDG;
            _drugTDG = drugTDG;
        }

        // [HttpPost]
        // public async Task<IActionResult> UploadRecord(string[] drugNames, string[] drugDescs)
        // {
        // Here, you'd use the planId to generate a plan
        // This is a placeholder for your existing logic
        // For now, we'll just redirect to the Index view as a placeholder
        // MedicalPlanManagement medicalPlanManagement = new MedicalPlanManagement(_medicalPlanTDG);

        // foreach (String name in drugNames)
        // {
        //     Console.WriteLine("Name is: " + name);
        //     DrugRecord tempDrugRecord = new DrugRecord();
        //     Drug drugs = new Drug
        //     {
        //         DrugName = name,
        //         DrugInformation = "good info"
        //     };
        //     tempDrugRecord.Drugs.Add(drugs);
        //     tempDrugRecord.PatientID = 1;
        //     await _drugRecordTDG.CreateDrugRecordAsync(tempDrugRecord);
        // }

        // foreach (String desc in drugDescs)
        // {
        //     Console.WriteLine("Desc is: " + desc);
        // }
        // var drugRecords = await _drugRecordTDG.GetDrugRecordByPatientIdAsync(1);


        // _logger.LogInformation("Generating plan for plan ID {PlanId}", drugName);
        // return RedirectToAction("Index");
        // }
        // public async Task<IActionResult> UploadRecord()
        // {
        //     Console.WriteLine("I am in upload record page");
        //     // var drugRecords = await _drugRecordTDG.GetDrugRecordByPatientIdAsync(1);
        //     // if (drugRecords != null)
        //     // {
        //     //     Console.WriteLine(drugRecords.ToString());
        //     // }    

        //     // var patientID = 1;

        //     // List<Drug> drugs = new List<Drug>();
        //     // drugs.Add(await _drugTDG.GetDrugByDrugIdAsync(1));
        //     // drugs.Add(await _drugTDG.GetDrugByDrugIdAsync(2));
        //     // DrugRecordManagement ac = new(_drugRecordTDG);
        //     // ac.createDrugRecord(patientID, drugs);


        //     // return View(ac.retrieveRecord(patientID));
        //     return View();
        // }

        // public async Task<IActionResult> UploadRecord()
        // {
        //     var patientID = 1;

        //     List<Drug> drugs = new List<Drug>
        //     {
        //         await _drugTDG.GetDrugByDrugIdAsync(1),
        //         await _drugTDG.GetDrugByDrugIdAsync(2)
        //     };

        //     DrugRecordManagement ac = new DrugRecordManagement(_drugRecordTDG);
        //     await ac.createDrugRecord(patientID, drugs);

        //     var record = await ac.retrieveRecord(patientID);

        //     return View(record);
        // }
        // public IActionResult UploadRecord()
        // {
        //     DrugRecordManagement ac = new DrugRecordManagement(_drugRecordTDG);

        //     DrugManagement dm = new DrugManagement(_drugTDG);
        //     // Console.WriteLine("DMDM: " + dm.retrieveAllDrug().Count);
        //     // foreach (Drug d in dm.retrieveAllDrug())
        //     // {
        //     //     Console.WriteLine("Test: " + d.DrugName);
        //     // }
        //     // Console.WriteLine("Single is " + dm.retrieveDrug(2).DrugName);

        //     // DrugRecord temp = new DrugRecord();
        //     // temp.PatientID = 1;
        //     // temp.Drugs.Add(dm.retrieveDrug(1));
        //     // temp.Drugs.Add(dm.retrieveDrug(3));
        //     // temp.Drugs.Add(dm.retrieveDrug(5));
        //     // List<Drug> drugs = new List<Drug>();
        //     // drugs.Add(dm.retrieveDrug(1));
        //     // drugs.Add(dm.retrieveDrug(3));
        //     // drugs.Add(dm.retrieveDrug(5));
        //     // Console.WriteLine("AC is 1: " + ac.retrieveRecord(2));
        //     // ac.createDrugRecord(2, drugs);
        //     // Console.WriteLine("AC is 2: " + ac.retrieveRecord(2));
        //     return View(dm.retrieveAllDrug());
        // }
        [HttpPost]
        public IActionResult UploadRecord(long[] drugNames, string[] drugDescs)
        {
            // Ensure drugNames and drugDescs are not null and have the same length
            if (drugNames == null)
            {
                // Handle error - Redirect to an error page or return an error response
                return RedirectToAction("Error");
            }

            DrugRecordManagement drugRecordManagement = new DrugRecordManagement(_drugRecordTDG);
            List<KeyValuePair<Drug, string>> drugsWithDesc = new List<KeyValuePair<Drug, string>>();

            for (int i = 0; i < drugNames.Length; i++)
            {
                var drugName = drugNames[i];
                var drugDesc = "";
                if (i <= drugDescs.Length)
                    drugDesc = drugDescs[i];
                // Assuming Drug constructor or a method to create a Drug from name
                // var drug = new Drug { DrugName = drugName };

                var drug = _drugTDG.GetDrugByDrugId(drugName);
                Console.WriteLine("Drug to insert into is: " + drug.DrugName);
                var pair = new KeyValuePair<Drug, string>(drug, drugDesc);
                drugsWithDesc.Add(pair);
            }

            // Assuming createDrugRecord expects a patientId and a list of KeyValuePair<Drug, string>
            drugRecordManagement.createDrugRecord(1, drugsWithDesc);
            Console.WriteLine("Creating!!!");
            // _logger.LogInformation("Generating plan for plan ID {PlanId}", planId);
            return RedirectToAction("UploadRecord");
        }

        public IActionResult UploadRecord()
        {
            DrugRecordManagement ac = new DrugRecordManagement(_drugRecordTDG);

            DrugManagement dm = new DrugManagement(_drugTDG);

            long patientID = 1;
            var viewModel = new DrugRecordViewModel
            {
                Drugs = dm.retrieveAllDrug(),
                DrugRecordDrug = ac.retrieveDrugRecordDrugs(patientID)
                // DrugRecord = ac.retrieveRecord(patientID)
            };
            Console.WriteLine("DrugRecordDrug:" + ac.retrieveDrugRecordDrugs(patientID));
            foreach (DrugRecordDrug z in ac.retrieveDrugRecordDrugs(patientID))
            {
                Console.WriteLine("?: " + z.DrugRecordDescription);
            }
            return View(viewModel);
        }
        public IActionResult Index()
        {
            Console.WriteLine("I am in index page");
            return View();
        }


    }

    internal class DrugRecordViewModel
    {
        public List<Drug> Drugs { get; set; }
        // public List<DrugRecord> DrugRecord { get; set; }
        public List<DrugRecordDrug> DrugRecordDrug { get; set; }
    }
}