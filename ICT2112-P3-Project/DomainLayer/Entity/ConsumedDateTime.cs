using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public partial class ConsumedDateTime
    {
        public long MedicationTrackerId { get; set; }
        public DateTime DateTime { get; set; }

        public virtual MedicationTracker MedicationTracker { get; set; } = null!;
    }
}