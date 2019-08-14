using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using team8.Models;

namespace team8
{
    public static class Session
    {
        static int customerID;
        static int employeeID;
        static int opsManagerID;

        public static int CustomerID
        {
            get
            {
                return customerID;
            }
            set
            {
                customerID = value;
            }
        }
        public static int EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                employeeID = value;
            }
        }
        public static int OpsManagerID
        {
            get
            {
                return opsManagerID;
            }
            set
            {
                opsManagerID = value;
            }
        }
        public static class Checkout
        {
            public static Order order { get; set; }
            public static Catalog catalog { get; set; }
            public static Customer customer { get; set; }
            public static Payment payment { get; set; }
        }




    }
}
