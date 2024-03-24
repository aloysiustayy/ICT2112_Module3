namespace PresentationLayer.Views.ViewModel
{
    public class MedicationEntryViewModel
    {
        public List<MedicationEntry> MedicationEntries { get; set; } = new List<MedicationEntry>();
    }

    public class MedicationEntry
    {
        public string DrugID { get; set; }
        public int TimesPerDay { get; set; }
        public bool BeforeMeals { get; set; }
        public string Day { get; set; }
    }
}