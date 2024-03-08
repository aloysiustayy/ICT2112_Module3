using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class Audit
{
    public long ActionId { get; set; }

    public string ActionType { get; set; } = null!;

    public string ActionPerformed { get; set; } = null!;

    public string ActionTimestamp { get; set; } = null!;

    public long ActionBy { get; set; }

    public virtual Administrator ActionByNavigation { get; set; } = null!;
}
