﻿using System;
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
        [Required]
        [Display(Name = "Job Type")]
        public string JobType{ get; set; }

        [Required]
        public string Media { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        [Display(Name = "Order Status")]
        public string OrderStatus { get; set; }
        [Required]
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }

        public int CardID { get; set; }

        [Display(Name = "Total Due")]
        public decimal TotalDue { get; set; }

        public virtual Customer customer { get; set; }
        public virtual Catalog catalog { get; set; }
        public virtual Payment payment { get; set; }


        public ICollection<Catalog> Catalog { get; set; }

        public string orderType { get; set; }

        public IEnumerable<Order> _lstOrders { get; set; }
    }






}
