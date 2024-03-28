namespace PresentationLayer.Views.ViewModel
{
    public class MedicationEntryViewModel
    {
        public List<MedicationEntry> MedicationEntries { get; set; } = new List<MedicationEntry>();
        public bool TrackPlan {  get; set; }
        public string PlanNotes {  get; set; }
        public DateTime PlanStart { get; set; }
        public DateTime PlanEnd { get; set; }
        public long PatientID { get; set; } = 2;
        public long AssignedByNurseID { get; set; } = 8;
    }

    public class MedicationEntry
    {
        public string DrugID { get; set; }
        public int TimesPerDay { get; set; }
        public bool BeforeMeals { get; set; }
    }
}