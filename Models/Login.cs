using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace team8.Models
{
    public class Login
    {
        //variables for temp use
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string UserType { get; set; }


        //all of the user types
        public Customer customer { get; set; }
        public Employee employee { get; set; }
        public OpsManager opsManager { get; set; }


    }
}
