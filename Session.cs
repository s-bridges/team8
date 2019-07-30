using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    }
}
