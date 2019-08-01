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
        public int CatalogID { get; set; }
        public int CustomerID { get; set; }
        [Display(Name = "Job Type")]
        public string JobType{ get; set; }
        public string Media { get; set; }

        public string Content { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        [Display(Name = "Order Status")]
        public string OrderStatus { get; set; }
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }

        public virtual Customer customer { get; set; }
        public virtual Catalog catalog { get; set; }
        public ICollection<Catalog> Catalog { get; set; }
    }






}
