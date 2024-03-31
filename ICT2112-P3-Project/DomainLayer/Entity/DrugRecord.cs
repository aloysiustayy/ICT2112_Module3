using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entity;

public partial class DrugRecord
{
    // public int accountID;
    [Key]
    public long DrugRecordID { get; set; }

    public long PatientID { get; set; }
    public string? DrugDescription { get; set; }

    // This is foreign key
    public ICollection<DrugRecordDrug> DrugRecordDrugs { get; set; }

    // Constructor
    public DrugRecord()
    {
        DrugRecordDrugs = new HashSet<DrugRecordDrug>();
    }
}