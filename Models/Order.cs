using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace team8.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        public string OrderStatus { get; set; }
        public string PaymentType { get; set; }


        public virtual Customer customer { get; set; }
        
        
    }






}
