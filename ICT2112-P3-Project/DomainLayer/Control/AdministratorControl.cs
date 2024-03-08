using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entity;
using DomainLayer.Interface;

namespace DomainLayer.Control
{
    public class AdministratorControl
    {
        private readonly IAdministratorTDG _administratorDbContext;

        public AdministratorControl(IAdministratorTDG administratorDbContext)
        {
            _administratorDbContext = administratorDbContext;
        }

        public List<Administrator> RetrieveAllAdministrativeAccount()
        {
            return _administratorDbContext.GetAllAdministrators();
        }

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
