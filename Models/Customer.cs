using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace team8.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }

        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public int CustomerZipcode { get; set; }
        [Phone]
        public string CustomerPhoneNumber { get; set; }
        public string CustomerUserName { get; set; }
        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }


        //creating the one to many relationship!!
        public ICollection<Payment> Payment { get; set; }
        public ICollection<Order> Order { get; set; }
      

    }
}
