using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team8.Models
{
    public class AllUsers
    {
        public virtual Customer customer { get; set; }
        public virtual Employee employee { get; set; }
        public virtual OpsManager opsManager { get; set; }

    }
}
