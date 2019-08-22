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
        static int catalogID;

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
        public static int CatalogID
        {
            get
            {
                return catalogID;
            }
            set
            {
                catalogID = value;
            }
        }

        public static class Checkout
        {
            public static Order order { get; set; }
            public static Catalog catalog { get; set; }
            public static Customer customer { get; set; }
            public static Payment payment { get; set; }
        }

        public static class Users
        {
            public static string userType { get; set; }
            public static  Customer customer { get; set; }
            public static  Employee employee { get; set; }
            public static  OpsManager opsManager { get; set; }

            public static IEnumerable<Customer> _lstCustomers { get; set; }
            public static IEnumerable<Employee> _lstEmployees { get; set; }
            public static IEnumerable<OpsManager> _lstOps { get; set; }
        }
 



    }
}
