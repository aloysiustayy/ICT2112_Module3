using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class RescheduleRequest
{
    public long ResceduleId { get; set; }

    public string AppointmentDateTime { get; set; } = null!;

    public long RequestStatus { get; set; }

    public string RescheduleReason { get; set; } = null!;

    public long ScheduleId { get; set; }

    public long PatientId { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual PreDischargeServiceSchedule Schedule { get; set; } = null!;
}
