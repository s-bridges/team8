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
        [Display(Name = "First Name")]
        public string EmployeeFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string EmployeeLastName { get; set; }
        [Display(Name = "Address")]
        public string EmployeeAddress { get; set; }
        [Display(Name = "City")]
        public string EmployeeCity { get; set; }
        [Display(Name = "State")]
        public string EmployeeState { get; set; }
        [Display(Name = "Zipcode")]
        public int EmployeeZipcode { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]
        public string EmployeePhoneNumber { get; set; }
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Display(Name = "User Name")]
        public string EmployeeUserName { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }
    }
}
