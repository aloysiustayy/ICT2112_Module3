using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class PreDischargeServiceLog
{
    public long ServiceLogId { get; set; }

    public string PostAppointmentNotes { get; set; } = null!;

    public string PostAppointmentObservation { get; set; } = null!;

    public long ScheduleId { get; set; }

    public virtual PreDischargeServiceSchedule Schedule { get; set; } = null!;
}
