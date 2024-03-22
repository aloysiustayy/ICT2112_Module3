namespace PresentationLayer.Views.ViewModel
{
    public class WeeklyMedicationPlanViewModel
    {
        public Dictionary<string, List<MedicationTask>> WeeklyPlan { get; set; } = new Dictionary<string, List<MedicationTask>>();
    }

    public class MedicationTask
    {
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public List<string> Times { get; set; } = new List<string>();
    }

    public class MedicationOption
    {
        public string Name { get; set; }
        public string Value { get; set; } // Optional, can be used as the actual value submitted by the form
    }


    public class MedicationViewModel
    {
        public List<MedicationOption> MedicationOptions { get; set; } = new List<MedicationOption>();
        public List<string> SelectedMedicationNames { get; set; } = new List<string>();
        public List<string> Dosage { get; set; } = new List<string>();
    }

    public class MedicationPlanViewModel
    {
        public List<MedicationOption> MedicationOptions { get; set; } = new List<MedicationOption>();
        public Dictionary<string, List<MedicationTask>> WeeklyPlan { get; set; } = new Dictionary<string, List<MedicationTask>>();
        // Add any additional properties needed for the form
    }

}