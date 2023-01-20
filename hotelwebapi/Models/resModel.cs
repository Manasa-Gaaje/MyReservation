using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi1.Models
{
    public class resModel
    {
        public int id { get; set; }
        public string Hotel { get; set; }
        public Nullable<System.DateTime> Arrival { get; set; }
        public Nullable<System.DateTime> Depature { get; set; }
        public string Type { get; set; }
        public Nullable<int> Guests { get; set; }
        public Nullable<int> price { get; set; }
    }
}
