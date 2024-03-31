using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entity;

public partial class DrugRecordDrug
{
    [Key]
    public long DrugRecordDrugID { get; set; }

    public long DrugId { get; set; }
    public Drug Drug { get; set; }
    public string? DrugRecordDescription { get; set; }

    public long PatientID { get; set; }
    public long DrugRecordID { get; set; }
    public DrugRecord DrugRecord { get; set; }
}