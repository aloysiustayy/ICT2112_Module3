using DomainLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface IDrug
    {
        public Drug RetrieveDrug(int drugID);
        public List<Drug> RetrieveAllDrug();
        public void CreateDrug(int drugId, string name, string desc);
        public void UpdateDrug(int drugID, string name, string description);
        public void DeleteDrug(int drugID);
    }
}