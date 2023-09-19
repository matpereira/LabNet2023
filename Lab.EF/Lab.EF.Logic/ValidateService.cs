using Lab.EF.Logic.DTO;
using System;
using System.Text.RegularExpressions;
using Lab.EF.Logic;

namespace Lab.EF.Logic
{
    public class ValidateService
    {
        public static void ValidateShipper(ShippersDTO shipper)
        {
            if (string.IsNullOrWhiteSpace(shipper.CompanyName))
            {
                throw new ArgumentException("El nombre de la compañía no puede estar vacío o contener solo espacios en blanco.", nameof(shipper.CompanyName));
            }

            if (shipper.CompanyName.Length > 40)
            {
                throw new ArgumentException("El nombre de la compañía no puede exceder los 40 caracteres.", nameof(shipper.CompanyName));
            }

            if (!IsPhoneNumberValid(shipper.Phone))
            {
                throw new ArgumentException("Número de teléfono no válido.", nameof(shipper.Phone));
            }
        }


    public static bool ValidateCustomer(CustomersDTO customer)
    {
        if (customer == null)
        {
            throw new ArgumentNullException(nameof(customer), "El objeto CustomerDTO no puede ser nulo.");
        }

        if (string.IsNullOrWhiteSpace(customer.CustomerID))
            {
            throw new ArgumentException("CustomerID no puede estar vacío o contener solo espacios en blanco.", nameof(customer.CustomerID));
        }

        if (customer.CustomerID.Length != 5)
            {
            throw new ArgumentException("CustomerID debe tener una longitud de 5 caracteres.", nameof(customer.CustomerID));
        }

        if (string.IsNullOrWhiteSpace(customer.CompanyName))
        {
            throw new ArgumentException("CompanyName no puede estar vacío o contener solo espacios en blanco.", nameof(customer.CompanyName));
        }

        if (customer.CompanyName.Length > 40)
        {
            throw new ArgumentException("CompanyName no puede tener más de 40 caracteres.", nameof(customer.CompanyName));
        }

        if (!string.IsNullOrWhiteSpace(customer.ContactName) && customer.ContactName.Length > 30)
        {
            throw new ArgumentException("ContactName no puede tener más de 30 caracteres.", nameof(customer.ContactName));
        }

        if (!string.IsNullOrWhiteSpace(customer.ContactTitle) && customer.ContactTitle.Length > 30)
        {
            throw new ArgumentException("ContactTitle no puede tener más de 30 caracteres.", nameof(customer.ContactTitle));
        }

        if (!string.IsNullOrWhiteSpace(customer.Address) && customer.Address.Length > 60)
        {
            throw new ArgumentException("Address no puede tener más de 60 caracteres.", nameof(customer.Address));
        }

        if (!string.IsNullOrWhiteSpace(customer.City) && customer.City.Length > 15)
        {
            throw new ArgumentException("City no puede tener más de 15 caracteres.", nameof(customer.City));
        }

        if (!string.IsNullOrWhiteSpace(customer.Region) && customer.Region.Length > 15)
        {
            throw new ArgumentException("Region no puede tener más de 15 caracteres.", nameof(customer.Region));
        }

        if (!string.IsNullOrWhiteSpace(customer.PostalCode) && customer.PostalCode.Length > 10)
        {
            throw new ArgumentException("PostalCode no puede tener más de 10 caracteres.", nameof(customer.PostalCode));
        }

        if (!string.IsNullOrWhiteSpace(customer.Country) && customer.Country.Length > 15)
        {
            throw new ArgumentException("Country no puede tener más de 15 caracteres.", nameof(customer.Country));
        }

        if (!IsPhoneNumberValid(customer.Phone))
        {
            throw new ArgumentException("Número de teléfono no válido.", nameof(customer.Phone));
        }

        if (!IsPhoneNumberValid(customer.Fax))
        {
            throw new ArgumentException("Número de teléfono no válido.", nameof(customer.Fax));
        }

        return true; 
    }

        public static bool IsPhoneNumberValid(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return true;
            }
            var pattern = @"^(?=\(?\+?\d{1,3}\)?)(?=.{1,24}$)\(?\+?\d{1,3}\)?[\s-]?\d{1,24}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
    }

}


