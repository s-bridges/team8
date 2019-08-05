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

        [Display (Name = "Billing Address")]
        public string BillingAddress { get; set; }
        [Display(Name = "Billing City")]
        public string BillingCity { get; set; }
        [Display(Name = "Billing State")]
        public string BillingSTate { get; set; }
        [Display(Name = "Billing Zipcode")]
        public string BillingZipcode { get; set; }
        [Display(Name = "Card Number")]
        public int CardNumber { get; set; }
        [Display(Name = "Card Type")]
        public string CardType { get; set; }
        [Display(Name = "Name on Card")]
        public string CardName { get; set; }
        [Display(Name = "Experation Date")]
        public string CardExpDate { get; set; }
        [Display(Name = "CVV (3-Digit Code)")]
        public string CardCVV { get; set; }

        public virtual Customer customer { get; set; }
        public IEnumerable<Payment> lstPayment { get; set; }
    }

}
