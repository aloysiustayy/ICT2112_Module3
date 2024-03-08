using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class PreDischargeService
{
    public long ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public string ServiceDescription { get; set; } = null!;

    public long ServiceDuration { get; set; }

    public virtual ICollection<PreDischargeServiceAssignment> PreDischargeServiceAssignments { get; set; } = new List<PreDischargeServiceAssignment>();
}
