using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entity;

namespace DomainLayer.Interface
{
    public interface ISafetyChecklistTDG
    {
        SafetyChecklist GetSafetyChecklistById(int safetyChecklistId);
        public IEnumerable<SafetyChecklist> GetAllSafetyChecklists();

        void CreateSafetyChecklist(SafetyChecklist safetyChecklist);
        void UpdateSafetyChecklist(SafetyChecklist safetyChecklist);
        void DeleteSafetyChecklist(int safetyChecklistId);
    }
}