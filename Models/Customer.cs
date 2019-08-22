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
        [Required]
        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string CustomerAddress { get; set; }
        [Required]
        [Display(Name = "City")]
        public string CustomerCity { get; set; }
        [Required]
        [Display(Name = "State")]
        public string CustomerState { get; set; }
        [Required]
        [Display(Name = "Zipcode")]
        public int CustomerZipcode { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string CustomerPhoneNumber { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string CustomerUserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }


        //creating the one to many relationship!!
        public ICollection<Payment> Payment { get; set; }
        public ICollection<Order> Order { get; set; }
        public IEnumerable<Order> _lstOrders { get; set; }



    }
}
