using DomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface ISafetyChecklist
    {
        void updateSafetyChecklist(string locationCategory, string riskTitle, string riskDescription, Photo photo);
        SafetyChecklist getSafetyChecklist();
    }
}

