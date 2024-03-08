using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class FollowUpAppointmentRecord
{
    public long FollowUpAppointmentId { get; set; }

    public string FollowUpAppointmentDate { get; set; } = null!;

    public virtual ICollection<DischargeRecord> DischargeRecords { get; set; } = new List<DischargeRecord>();
}
