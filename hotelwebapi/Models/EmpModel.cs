using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi1.Models
{

    public partial class EmpModel
    {
        public string Name { get; set; }
        public int id { get; set; }
        public Nullable<decimal> phonenumber { get; set; }
        public string Address { get; set; }
        public string city { get; set; }
        public string Country { get; set; }
        public Nullable<int> age { get; set; }
    }
}
    


