using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Lab.EF.Logic.DTO;

namespace Lab.EF.Logic
{
    public class CustomersLogic : BaseLogic, ILogic<Customers, CustomersDTO>
    {
        public List<CustomersDTO> GetAll()
        {
            return context.Customers
                .Select(customer => new CustomersDTO
                {
                    CustomerID = customer.CustomerID,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Address = customer.Address,
                    City = customer.City,
                    Region = customer.Region,
                    PostalCode = customer.PostalCode,
                    Country = customer.Country,
                    Phone = customer.Phone,
                    Fax = customer.Fax
                })
                .ToList();
        }

        public void Add(CustomersDTO customer)
        {
            var customerToAdd = new Customers
            {
                CustomerID = customer.CustomerID,
                CompanyName = customer.CompanyName,
                ContactName = customer?.ContactName,
                ContactTitle = customer?.ContactTitle,
                Address = customer?.Address,
                City = customer?.City,
                Region = customer?.Region,
                PostalCode = customer?.PostalCode,
                Country = customer?.Country,
                Phone = customer?.Phone,
                Fax = customer?.Fax
            };
            context.Customers.Add(customerToAdd);
            context.SaveChanges();
        }

        public void Update(CustomersDTO customer)
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

public void Delete(string id)
{
    try
    {
        // Buscar el cliente por su CustomerID
        var customerToDelete = context.Customers.FirstOrDefault(x => x.CustomerID == id);

        if (customerToDelete != null)
        {
            // Verificar si hay pedidos asociados al cliente
            var ordersWithCustomer = context.Orders.Any(o => o.CustomerID == id);

            if (!ordersWithCustomer)
            {
                // No hay pedidos asociados, se puede eliminar
                context.Customers.Remove(customerToDelete);
                context.SaveChanges();
            }
            else
            {
                // Hay pedidos asociados, mostrar un mensaje de error o tomar alguna acción adecuada
                Console.WriteLine("No se puede eliminar un cliente que esté asociado a un pedido");
            }
        }
        else
        {
            // El cliente no fue encontrado, mostrar un mensaje de error o tomar alguna acción adecuada
            Console.WriteLine("Cliente no encontrado");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al eliminar el cliente: {ex.Message}");
    }
}
        public CustomersDTO Find(string id)
        {
            var customer = context.Customers.Find(id);

            if (customer != null)
            {
                return new CustomersDTO
                {
                    CustomerID = customer.CustomerID,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Address = customer.Address,
                    City = customer.City,
                    Region = customer.Region,
                    PostalCode = customer.PostalCode,
                    Country = customer.Country,
                    Phone = customer.Phone,
                    Fax = customer.Fax
                };
            }
            else
            {
                return null;
            }
        }
    }
}

