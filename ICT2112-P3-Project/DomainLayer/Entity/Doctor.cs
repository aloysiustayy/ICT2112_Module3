﻿using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class Doctor
{
    public long DoctorId { get; set; }

    public string Identifier { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Nric { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public long PhoneNumber { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string PreferredNotificationPlatform { get; set; } = null!;

    public virtual ICollection<PreDischargeServiceAssignment> PreDischargeServiceAssignments { get; set; } = new List<PreDischargeServiceAssignment>();
}
