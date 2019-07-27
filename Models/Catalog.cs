using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace team8.Models
{
    public class Catalog
    {
        [Key]
        public int CatalogID { get; set; }

        public string ItemPhoto { get; set; }
        public string ItemName { get; set; }
        public string ItemStock { get; set; }
        public string ItemPrice { get; set; }

        public virtual Order order { get; set; }
    }
}
