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
        public void SetPlanDetails(bool trackPlan, string notes, DateTime start, DateTime end, long patientId, long assignedByNurseId);
        PatientMedicalPlan Build();

    }
}
