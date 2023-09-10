using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab.EF.UI.Customers
{
    public class CustomersUIFunctions
    {
        public static void NuevoCustomer(CustomersLogic customerLogic)
        {
            Console.WriteLine("Ingrese el nombre de la compañía (máximo 40 caracteres):");
            var nombreCompania = UIFunctions.LeerCadenaConLongitudMaxima("", 40);

            Console.WriteLine("Ingrese el nombre de contacto (máximo 30 caracteres):");
            var nombreContacto = UIFunctions.LeerCadenaConLongitudMaxima("", 30);

            Console.WriteLine("Ingrese el título de contacto (máximo 30 caracteres):");
            var tituloContacto = UIFunctions.LeerCadenaConLongitudMaxima("", 30);

            Console.WriteLine("Ingrese la dirección (máximo 60 caracteres):");
            var direccion = UIFunctions.LeerCadenaConLongitudMaxima("", 60);

            Console.WriteLine("Ingrese la ciudad (máximo 15 caracteres):");
            var ciudad = UIFunctions.LeerCadenaConLongitudMaxima("", 15);

            Console.WriteLine("Ingrese la región (máximo 15 caracteres):");
            var region = UIFunctions.LeerCadenaConLongitudMaxima("", 15);

            Console.WriteLine("Ingrese el código postal (máximo 10 caracteres):");
            var codigoPostal = UIFunctions.LeerCadenaConLongitudMaxima("", 10);

            Console.WriteLine("Ingrese el país (máximo 15 caracteres):");
            var pais = UIFunctions.LeerCadenaConLongitudMaxima("", 15);

            Console.WriteLine("Ingrese el número de teléfono (Max 24 dígitos):");
            var numeroTelefono = Console.ReadLine();

            Console.WriteLine("Ingrese el número de fax (Max 24 dígitos):");
            var numeroFax = Console.ReadLine();

            customerLogic.Add(new CustomersDTO
            {
                CompanyName = nombreCompania,
                ContactName = nombreContacto,
                ContactTitle = tituloContacto,
                Address = direccion,
                City = ciudad,
                Region = region,
                PostalCode = codigoPostal,
                Country = pais,
                Phone = numeroTelefono,
                Fax = numeroFax
            });
        }

        public static void ObtenerCustomers(CustomersLogic customerLogic)
        {
            var customers = customerLogic.GetAll();
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.CustomerID}\t| {customer.CompanyName}\t| {customer.ContactName}\t| {customer.ContactTitle}\t| {customer.City}\t| {customer.Phone}");
            }
        }


        public static void ModificarCustomer(CustomersLogic customerLogic)
        {
            Console.WriteLine("Ingrese el ID del cliente a modificar (longitud = 5):");
            string id = Console.ReadLine();

            if (id.Length == 5)
            {
                var customerDTO = customerLogic.Find(id);

                if (customerDTO != null)
                {
                    Console.WriteLine("Modificar el número de teléfono? (S/N)");
                    var confirmarTelefono = Console.ReadLine();
                    string nuevoTelefono = customerDTO.Phone;

                    if (confirmarTelefono == "S" || confirmarTelefono == "s")
                    {
                        nuevoTelefono = UIFunctions.LeerCadenaConLongitudMaxima("Ingrese el nuevo número de teléfono (Max 24 dígitos):", 24);
                        if (!UIFunctions.EsNumeroTelefonoValido(nuevoTelefono))
                        {
                            Console.WriteLine("Número de teléfono no válido.");
                            return;
                        }
                    }

                    customerLogic.Update(new CustomersDTO
                    {
                        CustomerID = customerDTO.CustomerID,
                        CompanyName = customerDTO.CompanyName,
                        ContactName = customerDTO.ContactName,
                        ContactTitle = customerDTO.ContactTitle,
                        City = customerDTO.City,
                        Country = customerDTO.Country,
                        PostalCode = customerDTO.PostalCode,
                        Region = customerDTO.Region,
                        Phone = nuevoTelefono,
                        Address = customerDTO.Address,
                        Fax = customerDTO.Fax
                    });

                    Console.WriteLine("Cliente actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("El ID ingresado no existe.");
                }
            }
            else
            {
                Console.WriteLine("Solo se aceptan ID de longitud = 5.");
            }
        }

        public static void BorrarCustomer(CustomersLogic customerLogic)
        {
            Console.Clear();
            Console.WriteLine("Selecciona el ID del cliente a eliminar (longitud = 5):");
            string id = Console.ReadLine();

            if (id.Length == 5)
            {
                var customerDTO = customerLogic.Find(id);

                if (customerDTO != null)
                {
                    Console.WriteLine("¿Está seguro que desea eliminar el registro?");
                    Console.WriteLine("Escriba S para confirmar u otra letra para cancelar.");
                    var confirmacion = Console.ReadLine();
                    if (confirmacion == "S" || confirmacion == "s")
                    {
                        customerLogic.Delete(id);
                        Console.WriteLine("Cliente eliminado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Eliminación cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("El ID ingresado no existe.");
                }
            }
            else
            {
                Console.WriteLine("Solo se aceptan ID de longitud = 5.");
            }
        }
    }
}
