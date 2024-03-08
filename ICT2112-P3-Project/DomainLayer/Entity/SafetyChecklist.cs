using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class SafetyChecklist
{
    public long SafetyChecklistId { get; set; }

    public string LocationCategory { get; set; } = null!;

    public string RiskTitle { get; set; } = null!;

    public string RiskDescription { get; set; } = null!;

    public string RiskComment { get; set; } = null!;

    public long PhotoId { get; set; }
}
