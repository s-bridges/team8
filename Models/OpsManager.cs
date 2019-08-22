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
        [Required]
        [Display(Name = "First Name")]
        public string OpsManagerFirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string OpsManagerLastName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string OpsManagerAddress { get; set; }
        [Required]
        [Display(Name = "City")]
        public string OpsManagerCity { get; set; }
        [Required]
        [Display(Name = "State")]
        public string OpsManagerState { get; set; }
        [Required]
        [Display(Name = "Zipcode")]
        public int OpsManagerZipcode { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string OpsManagerPhoneNumber { get; set; }
        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string OpsManagerUserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string OpsManagerPassword { get; set; }

        public string userType { get; set; }
        public string orderType { get; set; }
    }
}
