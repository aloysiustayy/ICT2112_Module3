﻿using DomainLayer.Control;
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

        private long patientID = 2;

        public DrugRecordController(ILogger<DrugRecordController> logger, IDrugRecordTDG drugRecordTDG, IDrugTDG drugTDG)
        {
            _logger = logger;
            _drugRecordTDG = drugRecordTDG;
            _drugTDG = drugTDG;
        }

        [HttpPost]
        public IActionResult UploadRecord(long[] drugIDs, string[] drugDescs)
        {
            // Ensure drugNames and drugDescs are not null and have the same length
            if (drugIDs == null)
            {
                // Handle error - Redirect to an error page or return an error response
                return RedirectToAction("Error");
            }

            DrugRecordManagement drugRecordManagement = new DrugRecordManagement(_drugRecordTDG);
            List<KeyValuePair<Drug, string>> drugsWithDesc = new List<KeyValuePair<Drug, string>>();

            for (int i = 0; i < drugIDs.Length; i++)
            {
                var drugID = drugIDs[i];
                var drugDesc = drugDescs[i];
                // Assuming Drug constructor or a method to create a Drug from name
                // var drug = new Drug { DrugName = drugName };

                var drug = _drugTDG.GetDrugByDrugId(drugID);
                Console.WriteLine("Drug to insert into is: " + drug.DrugName);
                var pair = new KeyValuePair<Drug, string>(drug, drugDesc);
                drugsWithDesc.Add(pair);
            }

            // Assuming createDrugRecord expects a patientId and a list of KeyValuePair<Drug, string>
            drugRecordManagement.CreateDrugRecord(patientID, drugsWithDesc);
            Console.WriteLine("Creating!!!");

            return RedirectToAction("UploadRecord");
        }

        public IActionResult UploadRecord()
        {
            DrugRecordManagement ac = new DrugRecordManagement(_drugRecordTDG);

            DrugManagement dm = new DrugManagement(_drugTDG);


            var viewModel = new DrugRecordViewModel
            {
                Drugs = dm.RetrieveAllDrug(),
                DrugRecordDrug = ac.RetrieveDrugRecordDrugs(patientID)
                // DrugRecord = ac.retrieveRecord(patientID)
            };
            Console.WriteLine("DrugRecordDrug:" + ac.RetrieveDrugRecordDrugs(patientID));
            foreach (DrugRecordDrug z in ac.RetrieveDrugRecordDrugs(patientID))
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