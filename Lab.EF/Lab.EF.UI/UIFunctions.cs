using Lab.EF.Logic;
using System;
using System.Text.RegularExpressions;

namespace Lab.EF.UI
{
    internal class UIFunctions
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
            bool esValido = false;
            string patron = @"^(?:(\+54|0)(?:(?:(?:11|[2368]\d)(?:\s*[ -]?\d{4}){2})|(?:(?:[2368]\d\s*[-]?)?(?:\s*[ -]?\d{3}\s*[ -]?)?\d{4})))|(11\d{8})(?:\s*[ -]?\d{4}){0,5}$";
            esValido = Regex.IsMatch(numero, patron);

            if(esValido == false)
            {
                Console.WriteLine("Número de teléfono no válido.");
                Console.WriteLine();
                Console.WriteLine("Formatos de numero validos: ");
                Console.WriteLine("(+54) 91123456789 (celular)\r\n011 2345 6789 (fijo)\r\n236 123 4567 (fijo)\r\n1161234567 (celular)");
                Console.WriteLine();
            }
            return esValido;
        }

    }
}
