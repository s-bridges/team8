using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team8.Models
{
    public class Order_Catalog
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        
        public string OrderStatus { get; set; }
        public string PaymentType { get; set; }
    }
}
