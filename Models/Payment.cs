using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace team8.Models
{
    public class Payment
    {

        [Key]
        public int CardID { get; set; }


        public Nullable<int> CustomerID { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingSTate { get; set; }
        public string BillingZipcode { get; set; }
        public int CardNumber { get; set; }
        public string CardType { get; set; }
        public string CardName { get; set; }

        public string CardExpDate { get; set; }
        public string CardCVV { get; set; }

        public virtual Customer customer { get; set; }
    }

}
