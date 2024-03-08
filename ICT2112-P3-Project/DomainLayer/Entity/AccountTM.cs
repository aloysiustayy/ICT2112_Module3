using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public abstract class AccountTM
    {
        [Required]
        public string Identifier { get; set; }

        [Column(TypeName = "TEXT")]
        public string Password { get; set; }

        [Column(TypeName = "TEXT")]
        public string NRIC { get; set; }

        [Column(TypeName = "TEXT")]
        public string FullName { get; set; }

        [Column(TypeName = "TEXT")]
        public string Nationality { get; set; }

        [Column(TypeName = "INTEGER")]
        public int PhoneNumber { get; set; }

        [Column(TypeName = "TEXT")]
        public string EmailAddress { get; set; }

        [Column(TypeName = "TEXT")]
        public string PreferredNotificationPlatform { get; set; }
    }
}
