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
    public long DrugID { get; set; } // this is probably not needed.. cause drugid is taken from DrugRecordDrug
    public string? DrugDescription { get; set; }

    // This is foreign key
    public virtual ICollection<Drug> Drugs { get; set; } = new List<Drug>();
    public ICollection<DrugRecordDrug> DrugRecordDrugs { get; set; }

    // Constructor
    public DrugRecord()
    {
        DrugRecordDrugs = new HashSet<DrugRecordDrug>();
    }
}