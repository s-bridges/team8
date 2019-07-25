using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace team8.Models
{
    public class Order_Catalog
    {
        [Key]
        public int Order_CatalogID { get; set; }
        public int OrderID { get; set; }
        public int CatalogID { get; set; }

        public string jobDescription { get; set; }
        public string media { get; set; }
            public string content { get; set; }
        public int quantity { get; set; }
        public string priceEach { get; set; }

        public ICollection<Catalog> Catalog { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
