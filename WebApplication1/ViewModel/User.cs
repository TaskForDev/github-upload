using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class User
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        //public string Surname { get; set; }
        public decimal Discount { get; set; }
        public string Address { get; set; }
        public List<string> Subscription { get; set; }
    }
}
