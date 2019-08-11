using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace team8.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string EmployeeFirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string EmployeeLastName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string EmployeeAddress { get; set; }
        [Required]
        [Display(Name = "City")]
        public string EmployeeCity { get; set; }
        [Required]
        [Display(Name = "State")]
        public string EmployeeState { get; set; }
        [Required]
        [Display(Name = "Zipcode")]
        public int EmployeeZipcode { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string EmployeePhoneNumber { get; set; }
        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string EmployeeUserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }
    }
}
