using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab.EF.Logic
{
    public class CustomersLogic : BaseLogic
    {

        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }

        public void Add(Customers customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void Update(Customers customer)
        {
            var customerToUpdate = context.Customers.Find(customer.CustomerID);
            customerToUpdate.CompanyName = customer.CompanyName;
            customerToUpdate.ContactName = customer?.ContactName;
            customerToUpdate.ContactTitle = customer?.ContactTitle;
            customerToUpdate.Address = customer?.Address;
            customerToUpdate.City = customer?.City;
            customerToUpdate.Region = customer?.Region;
            customerToUpdate.PostalCode = customer?.PostalCode;
            customerToUpdate.Country = customer?.Country;
            customerToUpdate.Phone = customer?.Phone;
            customerToUpdate.Fax = customer?.Fax;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                var customerToDelete = context.Customers.FirstOrDefault(x => x.CustomerID == id.ToString());
                context.Customers.Remove(customerToDelete);
                context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("No se puede eliminar un shipper que este asociado a un pedido");
            }
        }
    }
}
