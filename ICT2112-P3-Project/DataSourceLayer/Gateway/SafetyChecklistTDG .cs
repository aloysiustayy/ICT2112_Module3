using DomainLayer.Entity;
using DataSourceLayer.Data;
using DomainLayer.Interface;

namespace DataSourceLayer.Gateway
{
    public class SafetyChecklistTDG : ISafetyChecklistTDG
    {
        private readonly DataContext _context;

        public SafetyChecklistTDG(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<SafetyChecklist> GetAllSafetyChecklists()
        {
            return _context.SafetyChecklists.ToList();
        }

        public SafetyChecklist GetSafetyChecklistById(int safetyChecklistId)
        {
            return _context.SafetyChecklists.Find(safetyChecklistId);
        }

        public void AddSafetyChecklist(SafetyChecklist safetyChecklist)
        {
            _context.SafetyChecklists.Add(safetyChecklist);
            _context.SaveChanges();
        }

        public void UpdateSafetyChecklist(SafetyChecklist safetyChecklist)
        {
            _context.SafetyChecklists.Update(safetyChecklist);
            _context.SaveChanges();
        }

        public void DeleteSafetyChecklist(int safetyChecklistId)
        {
            var safetyChecklist = _context.SafetyChecklists.Find(safetyChecklistId);
            if (safetyChecklist != null)
            {
                _context.SafetyChecklists.Remove(safetyChecklist);
                _context.SaveChanges();
            }
        }
    }
}
