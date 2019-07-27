using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team8
{
    public static class Session
    {
        static int customerID;

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


    }
}
