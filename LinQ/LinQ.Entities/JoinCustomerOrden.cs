using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ.Entities
{
    public class JoinCustomerOrden
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public Customers Customer { get; set; }
        public int OrderCount { get; set; }

    }
}
