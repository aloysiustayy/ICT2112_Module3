using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entity;
using DomainLayer.Interface;

namespace DomainLayer.Control
{
    public class DrugManagement : IDrug
    {
        private readonly IDrugTDG _drugDbContext;

        public DrugManagement(IDrugTDG drugDbContext)
        {
            _drugDbContext = drugDbContext;
        }

        public Drug RetrieveDrug(int drugID)
        {
            return _drugDbContext.GetDrugByDrugId(drugID);
        }
        public List<Drug> RetrieveAllDrug()
        {
            return _drugDbContext.GetAllDrugs();
        }
        public void CreateDrug(int drugId, string name, string desc)
        {
            Drug tempDrug = new Drug
            {
                DrugId = drugId,
                DrugName = name,
                DrugInformation = desc,
                Inventory = 100
            };
            _drugDbContext.CreateDrug(tempDrug);
        }
        public void UpdateDrug(int drugID, string name, string description)
        {
            DeleteDrug(drugID);
            CreateDrug(drugID, name, description);
        }
        public void DeleteDrug(int drugID)
        {
            _drugDbContext.DeleteDrug(drugID);
        }

    }
}
