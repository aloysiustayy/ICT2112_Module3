using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class Documentation
{
    public long DocumentationId { get; set; }

    public long SafetyChecklist { get; set; }

    public long PatientId { get; set; }

    public virtual ICollection<DischargeRecord> DischargeRecords { get; set; } = new List<DischargeRecord>();
}
