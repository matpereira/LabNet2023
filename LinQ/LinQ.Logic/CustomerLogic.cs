using System;
using System.Linq;
using LinQ.Entities;

namespace LinQ.Logic
{
    public class CustomerLogic : BaseLogic
    {
        
        public Customers ObtenerCustomerPorId(string id)
        {
            string upperCaseCustomerID = id.ToUpper();

            return context.Customers.FirstOrDefault(customer => customer.CustomerID == upperCaseCustomerID);
     
        }

        public IQueryable<Customers> ObtenerCustomersWA ()
        {
            var clientesRegionWA = from c in context.Customers
                                   where c.Region == "WA"
                                   select c;

            return clientesRegionWA;
        }

        public IQueryable<string> ObtenerCustomerMayusMinus()
        {
            var nombresClientes = from c in context.Customers
                                  select c.CompanyName.ToUpper() + " | " + c.CompanyName.ToLower();

            return nombresClientes;
        }

        public IQueryable<ClienteYOrden> ObtenerClientesYOrdenes()
        {
            var clientesYOrdenesWA = from customer in context.Customers
                                     join order in context.Orders on customer.CustomerID equals order.CustomerID
                                     where customer.Region == "WA" && order.OrderDate > new DateTime(1997, 1, 1)
                                     select new ClienteYOrden
                                     {
                                         CustomerID = customer.CustomerID,
                                         CompanyName = customer.CompanyName,
                                         OrderID = order.OrderID,
                                         OrderDate = (DateTime)order.OrderDate
                                     };

            return clientesYOrdenesWA;
        }

        public class ClienteYOrden
        {
            public string CustomerID { get; set; }
            public string CompanyName { get; set; }
            public int OrderID { get; set; }
            public DateTime OrderDate { get; set; }
        }

    }
}
