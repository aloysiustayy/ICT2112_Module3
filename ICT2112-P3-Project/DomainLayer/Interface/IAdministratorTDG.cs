using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entity;

namespace DomainLayer.Interface
{
    public interface IAdministratorTDG
    {
        public List<Administrator> GetAllAdministrators();

        public Administrator GetAdministratorById(int administratorId);

        public void AddAdministrator(Administrator newAdministrator);

        public void UpdateAdministrator(Administrator existingAdministrator);
        
        public void DeleteAdministrator(int administratorId);
    }
}
