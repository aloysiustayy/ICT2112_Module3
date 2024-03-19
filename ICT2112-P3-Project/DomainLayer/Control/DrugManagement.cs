using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entity;
using DomainLayer.Interface;

namespace DomainLayer.Control
{
    public class DrugManagement
    {
        private readonly IDrugTDG _drugDbContext;

        public DrugManagement(IDrugTDG drugDbContext)
        {
            _drugDbContext = drugDbContext;
        }

        public Drug retrieveDrug(int drugID)
        {
            return _drugDbContext.GetDrugByDrugId(drugID);
        }
        public List<Drug> retrieveAllDrug()
        {
            return _drugDbContext.GetAllDrugs();
        }
        public void createDrug(int drugId, string name, string desc)
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



        // public List<Administrator> RetrieveAllAdministrativeAccount()
        // {
        //     return _administratorDbContext.GetAllAdministrators();
        // }


        /*        public void CreateAdministrativeAccount() {
                    Administrator c = new Administrator();
                    c.AdministratorId = 1;
                    c.Identifier = "admin1";
                    c.Password = "password123";
                    c.NRIC = "123456789";
                    c.FullName = "John Doe";
                    c.Nationality = "US";
                    c.PhoneNumber = 1234567890;
                    c.EmailAddress = "admin@example.com";
                    c.PreferredNotificationPlatform = "Email";

                    _administratorDbContext.AddAdministrator(c);
                }*/
    }
}
