using DomainLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface IDrugTDG
    {
        public List<Drug> GetAllDrugs();
        public Drug GetDrugByDrugId(long drugID);
        public void CreateDrug(Drug newDrug);
        public void UpdateDrug(Drug existingDrug);
        public void DeleteDrug(long patientID);
    }
}