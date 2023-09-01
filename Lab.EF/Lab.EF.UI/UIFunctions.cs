using Lab.EF.Logic;
using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Lab.EF.UI
{
    public class UIFunctions
    {
        
        public void ObtenerShippers(ShippersLogic shipperLogic)
        {
            Console.WriteLine("ID\t|\tNombre de la compania\t|\tTelefono");

            var shippers = shipperLogic.GetAll();
            foreach (var shipper in shippers)
            {
                if(shipper.CompanyName.Length < 16)
                    Console.WriteLine($"{shipper.ShipperID}\t|\t{shipper.CompanyName}\t\t\t|\t{shipper.Phone}");
                else
                Console.WriteLine($"{shipper.ShipperID}\t|\t{shipper.CompanyName}\t|\t{shipper.Phone}");
            }
        }

        public void ObtenerCustomers(CustomersLogic customerLogic)
        {
            var customers = customerLogic.GetAll();
            foreach (var customer in customers)
            {

                    Console.WriteLine($"{customer.CustomerID}\t| {customer.CompanyName}\t| {customer.ContactName}\t| {customer.ContactTitle}\t| {customer.City}\t| {customer.Phone}");
            }
        }

        public void mostrarMenu()
        {
            Console.WriteLine("1. Agregar Shipper");
            Console.WriteLine("2. Actualizar Shipper");
            Console.WriteLine("3. Eliminar Shipper");
            Console.WriteLine("4. Mostrar Shippers");
            Console.WriteLine("5. Mostrar Customers");
            Console.WriteLine("0. Salir");
        }

        public bool EsNumeroTelefonoValido(string numero)
        {
            //Aclaracion sobre esta Regex:

            //Permite un símbolo "+" opcional antes de dos dígitos.
            //Permite paréntesis opcionales alrededor del código de país.
            //Acepta guiones intermedios opcionales.
            //Acepta formatos como "(+54)911-2233-5544" o "+5491122335544".
            //Verifica que la longitud total sea de hasta 24 caracteres.
            string patron = @"^(?=\(?\+?\d{1,3}\)?)(?=.{1,24}$)\(?\+?\d{1,3}\)?[\s-]?\d{1,24}$";

            bool esValido = Regex.IsMatch(numero, patron);

            if (esValido == false)
            {
                Console.WriteLine("Número de teléfono no válido.");
                
            }
            return esValido;
        }

    }
}   
