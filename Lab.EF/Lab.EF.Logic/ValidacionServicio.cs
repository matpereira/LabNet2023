using Lab.EF.Logic.DTO;
using System;
using System.Text.RegularExpressions;

namespace Lab.EF.Logic
{
    public class ValidacionServicio
    {
        public static void ValidarShipper(ShippersDTO shipper)
        {
            if (string.IsNullOrWhiteSpace(shipper.CompanyName))
            {
                throw new ArgumentException("El nombre de la compañía no puede estar vacío o contener solo espacios en blanco.", nameof(shipper.CompanyName));
            }

            if (shipper.CompanyName.Length > 40)
            {
                throw new ArgumentException("El nombre de la compañía no puede exceder los 40 caracteres.", nameof(shipper.CompanyName));
            }

            if (!EsNumeroTelefonoValido(shipper.Phone))
            {
                throw new ArgumentException("Número de teléfono no válido.", nameof(shipper.Phone));
            }
        }

        public static bool EsNumeroTelefonoValido(string phoneNumber)
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


