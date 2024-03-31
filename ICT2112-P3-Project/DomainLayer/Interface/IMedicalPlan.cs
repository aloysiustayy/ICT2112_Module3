using DomainLayer.Entity;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface IMedicalPlan
    {
        public void GeneratePlan(PatientMedicalPlan medicalPlan);
        public void ExportPlan();
        public Task<string> ExecuteOCR(string base64EncodedImage);
    }
}