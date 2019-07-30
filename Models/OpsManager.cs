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
        public int EmployeeID { get; set; }
        public string OpsManagerFirstName { get; set; }
        public string OpsManagerLastName { get; set; }

        public string OpsManagerAddress { get; set; }
        public string OpsManagerCity { get; set; }
        public string OpsManagerState { get; set; }
        public int OpsManagerZipcode { get; set; }
        [Phone]
        public string OpsManagerPhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public string OpsManagerUserName { get; set; }
        [DataType(DataType.Password)]
        public string OpsManagerPassword { get; set; }
        public virtual Employee employee { get; set; }
    }
}
