using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team8.Models
{
    public class Checkout
    { 

        public Order order { get; set; }
        public Catalog catalog { get; set; }
        public Customer customer { get; set; }
        public Payment payment { get; set; }


    }
}
