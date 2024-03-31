using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public partial class MedicationTracker
    {
        public long TrackingId { get; set; }
        public int TimesPerDay { get; set; }
        public bool BeforeMeals { get; set; }
        public virtual ICollection<ConsumedDateTime> ConsumedOn { get; set; } = new List<ConsumedDateTime>();
        public DateTime HasNotified { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public MedicationTracker CreateTracker(int timesPerDay, bool beforeMeals)
        {
            var tracker = new MedicationTracker
            {
                TimesPerDay = timesPerDay,
                BeforeMeals = beforeMeals,
            };
            return tracker;
        }
    }
}