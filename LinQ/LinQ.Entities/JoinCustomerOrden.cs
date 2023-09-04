using System;

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
