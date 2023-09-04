using System;
using System.Collections.Generic;
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
            var clientesRegionWA = from customer in context.Customers
                                   where customer.Region == "WA"
                                   select customer;

            return clientesRegionWA;
        }

        public IQueryable<string> ObtenerCustomerMayusMinus()
        {
            var nombresCustomers = from customer in context.Customers
                                  select customer.CompanyName.ToUpper() + " | " + customer.CompanyName.ToLower();

            return nombresCustomers;
        }

        public IQueryable<JoinCustomerOrden> ObtenerCustomersYOrders()
        {
            var customersYOrdersWA = from customer in context.Customers
                                     join order in context.Orders on customer.CustomerID equals order.CustomerID
                                     where customer.Region == "WA" && order.OrderDate > new DateTime(1997, 1, 1)
                                     select new JoinCustomerOrden
                                     {
                                         CustomerID = customer.CustomerID,
                                         CompanyName = customer.CompanyName,
                                         OrderID = order.OrderID,
                                         OrderDate = (DateTime)order.OrderDate
                                     };

            return customersYOrdersWA;
        }

        public IQueryable<Customers> ObtenerPrimerosTresCustomerWA()
        {
            var primerosTresCustomersWA = (  from customer in context.Customers
                                            where customer.Region == "WA"
                                            select customer).Take(3);
            return primerosTresCustomersWA;
        }

        public List<JoinCustomerOrden> ObtenerCustomersConCantidadDeOrdenes()
        {
            var customersOrders = (from customer in context.Customers
                                      join order in context.Orders on customer.CustomerID equals order.CustomerID
                                      group order by customer into g
                                      select new JoinCustomerOrden
                                      {
                                          Customer = g.Key,
                                          OrderCount = g.Count()
                                      }).ToList();

            return customersOrders;
        }
    }


}

