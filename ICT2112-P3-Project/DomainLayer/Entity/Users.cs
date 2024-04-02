using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public partial class Users
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
    }
}
