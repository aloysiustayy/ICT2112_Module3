using DomainLayer.Entity;
using DataSourceLayer.Data;
using DomainLayer.Interface;

namespace DataSourceLayer.Gateway
{
    public class AdministratorTDG : IAdministratorTDG
    {
        private readonly DataContext _context;

        public AdministratorTDG(DataContext context)
        {
            _context = context;
        }

        public List<Administrator> GetAllAdministrators()
        {
            return _context.Administrators.ToList();
        }

        public Administrator GetAdministratorById(int administratorId)
        {
            return _context.Administrators.Find(administratorId);
        }

        public void AddAdministrator(Administrator newAdministrator)
        {
            _context.Administrators.Add(newAdministrator);
            _context.SaveChanges();
        }

        public void UpdateAdministrator(Administrator existingAdministrator)
        {
            _context.Administrators.Update(existingAdministrator);
            _context.SaveChanges();
        }

        public void DeleteAdministrator(int administratorId)
        {
            var existingAdministrator = _context.Administrators.Find(administratorId);
            if (existingAdministrator != null)
            {
                _context.Administrators.Remove(existingAdministrator);
                _context.SaveChanges();
            }
        }
    }
}
