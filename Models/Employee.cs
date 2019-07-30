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
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }

        public string EmployeeAddress { get; set; }
        public string EmployeeCity { get; set; }
        public string EmployeeState { get; set; }        
        public int EmployeeZipcode { get; set; }
        [Phone]
        public string EmployeePhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public string EmployeeUserName { get; set; }
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }
    }
}
