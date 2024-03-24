using DomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface IMedicalPlanBuilder
    {
        public void SetSelectedDrugs(List<Prescription> selectedDrugs);
        public void SetPrescriptions(List<Prescription> prescription);

        PatientMedicalPlan Build();

    }
}
