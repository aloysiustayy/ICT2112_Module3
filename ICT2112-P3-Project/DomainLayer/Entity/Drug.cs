﻿using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class Drug
{
    public long DrugId { get; set; }

    public string DrugName { get; set; } = null!;

    public string DrugInformation { get; set; } = null!;

    public long Inventory { get; set; }

    public virtual ICollection<PatientMedicalPlan> PatientMedicalPlans { get; set; } = new List<PatientMedicalPlan>();
}
