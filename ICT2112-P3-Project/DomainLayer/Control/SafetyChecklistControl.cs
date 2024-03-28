using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entity;
using DomainLayer.Interface;

namespace DomainLayer.Control
{
    public class SafetyChecklistControl
    {
        private readonly ISafetyChecklistTDG _safetyChecklistTDG;

        public SafetyChecklistControl(ISafetyChecklistTDG safetyChecklistTDG)
        {
            _safetyChecklistTDG = safetyChecklistTDG;
        }

        public IEnumerable<SafetyChecklist> RetrieveAllSafetyChecklists()
        {
            return _safetyChecklistTDG.GetAllSafetyChecklists();
        }

        public SafetyChecklist RetrieveSafetyChecklistById(int safetyChecklistId)
        {
            return _safetyChecklistTDG.GetSafetyChecklistById(safetyChecklistId);
        }

        public void AddSafetyChecklist(SafetyChecklist safetyChecklist)
        {
            _safetyChecklistTDG.AddSafetyChecklist(safetyChecklist);
        }

        public void UpdateSafetyChecklist(SafetyChecklist safetyChecklist)
        {
            _safetyChecklistTDG.UpdateSafetyChecklist(safetyChecklist);
        }

        public void RemoveSafetyChecklist(int safetyChecklistId)
        {
            _safetyChecklistTDG.DeleteSafetyChecklist(safetyChecklistId);
        }
    }
}
    
