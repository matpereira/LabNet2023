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
            try
            {
                ValidacionServicio.ValidaCustomer(customer);

                if (Find(customer.CustomerID)!= null)
                {
                    throw new ArgumentException("CustomerID ya existe en la base de datos.", nameof(customer.CustomerID));
                }

                var customerToAdd = new Customers
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

                context.Customers.Add(customerToAdd);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el cliente: " + ex.Message, ex);
            }
        }

        public void Update(CustomersDTO customer)
        {

            ValidacionServicio.ValidaCustomer(customer);

            var customerToUpdate = context.Customers.Find(customer.CustomerID);
            customerToUpdate.CompanyName = customer.CompanyName;
            customerToUpdate.ContactName = customer.ContactName;
            customerToUpdate.ContactTitle = customer.ContactTitle;
            customerToUpdate.Address = customer.Address;
            customerToUpdate.City = customer.City;
            customerToUpdate.Region = customer.Region;
            customerToUpdate.PostalCode = customer.PostalCode;
            customerToUpdate.Country = customer.Country;
            customerToUpdate.Phone = customer.Phone;
            customerToUpdate.Fax = customer.Fax;
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            try
            {
                var customerToDelete = context.Customers.FirstOrDefault(x => x.CustomerID.Equals(id, StringComparison.OrdinalIgnoreCase));

                if (customerToDelete != null)
                {
                    context.Customers.Remove(customerToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("No se encontró el Customer para eliminar.");
                }
            }
            catch
            {
                throw new Exception("No se puede eliminar este Customer");
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

