using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace team8.Models
{
    public class OpsManager
    {
        [Key]
        public int OpsManagerID { get; set; }
        [Display(Name = "First Name")]
        public string OpsManagerFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string OpsManagerLastName { get; set; }
        [Display(Name = "Address")]
        public string OpsManagerAddress { get; set; }
        [Display(Name = "City")]
        public string OpsManagerCity { get; set; }
        [Display(Name = "State")]
        public string OpsManagerState { get; set; }
        [Display(Name = "Zipcode")]
        public int OpsManagerZipcode { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]
        public string OpsManagerPhoneNumber { get; set; }
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Display(Name = "User Name")]
        public string OpsManagerUserName { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string OpsManagerPassword { get; set; }
    }
}
