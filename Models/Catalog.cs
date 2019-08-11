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
        [Required]
        [Display(Name = "Photo")]
        public string ItemPhoto { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string ItemName { get; set; }
        [Required]
        [Display(Name = "Stock")]
        public string ItemStock { get; set; }
        
        [Display(Name = "Price")]
        public decimal ItemPrice { get; set; }

        public virtual Order order { get; set; }
    }
}
