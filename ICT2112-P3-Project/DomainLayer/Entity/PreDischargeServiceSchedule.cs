using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class PreDischargeServiceSchedule
{
    public long ScheduleId { get; set; }

    public string AppointmentDateTime { get; set; } = null!;

    public string AssignmentStatus { get; set; } = null!;

    public long AssignmentId { get; set; }

    public virtual PreDischargeServiceAssignment Assignment { get; set; } = null!;

    public virtual ICollection<PreDischargeServiceLog> PreDischargeServiceLogs { get; set; } = new List<PreDischargeServiceLog>();

    public virtual ICollection<RescheduleRequest> RescheduleRequests { get; set; } = new List<RescheduleRequest>();
}
