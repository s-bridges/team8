using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team8.Models
{
    public class AllUsers
    {
        public string userType { get; set; }
        public virtual Customer customer { get; set; }
        public virtual Employee employee { get; set; }
        public virtual OpsManager opsManager { get; set; }

        public IEnumerable<Customer> _lstCustomers { get; set; }
        public IEnumerable<Employee> _lstEmployees { get; set; }
        public IEnumerable<OpsManager> _lstOps { get; set; }
    }
}
