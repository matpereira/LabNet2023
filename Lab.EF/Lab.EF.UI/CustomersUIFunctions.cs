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
            Console.WriteLine("Ingrese el ID del cliente (longitud = 5):");
            var id = Console.ReadLine();

            
            while(id.Length!=5)
            {
                Console.WriteLine("El ID debe tener una longitud de 5 caracteres.");
                Console.WriteLine("Ingrese el ID del cliente (longitud = 5):");
                id = Console.ReadLine();
            }

            Console.WriteLine("Ingrese el nombre de la compañía (máximo 40 caracteres):");
            var nombreCompania = UIFunctions.LeerCadenaConLongitudMaxima("", 40);

            Console.WriteLine("Ingrese el nombre de contacto (máximo 30 caracteres):");
            var nombreContacto = UIFunctions.LeerCadenaConLongitudMaxima("", 30);


            Console.WriteLine("Ingrese el país (máximo 15 caracteres):");
            var pais = UIFunctions.LeerCadenaConLongitudMaxima("", 15);

            Console.WriteLine("Ingrese el número de teléfono (Max 24 dígitos):");
            var numeroTelefono = Console.ReadLine();


            try
            {
                customerLogic.Add(new CustomersDTO
                {
                    CustomerID = id.ToUpper(),
                    CompanyName = nombreCompania,
                    ContactName = nombreContacto,
                    Country = pais,
                    Phone = numeroTelefono,
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el cliente: " + ex.Message);
            }

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
                try
                {
                    Console.WriteLine("Ingrese el ID del cliente a modificar (longitud = 5):");
                    string id = Console.ReadLine();

                    if (id.Length != 5)
                    {
                        Console.WriteLine("El ID debe tener una longitud de 5 caracteres.");
                        return;
                    }

                    var customerDTO = customerLogic.Find(id);

                    if (customerDTO == null)
                    {
                        Console.WriteLine("El ID ingresado no existe.");
                        return;
                    }

                    Console.WriteLine("Modificar el número de teléfono? (S/N)");
                    var confirmarTelefono = Console.ReadLine();
                    string nuevoTelefono = customerDTO.Phone;

                    if (confirmarTelefono == "S" || confirmarTelefono == "s")
                    {
                        Console.WriteLine("Ingrese el nuevo número de teléfono (Max 24 dígitos):");
                        nuevoTelefono = Console.ReadLine();

                        if (!UIFunctions.EsNumeroTelefonoValido(nuevoTelefono))
                        {
                            Console.WriteLine("Número de teléfono no válido.");
                            return;
                        }
                    }

                    Console.WriteLine("Modificar el nombre de la compañia? (S/N)");
                    var confirmarCompania = Console.ReadLine();
                    var compania=customerDTO.CompanyName;
                    if (confirmarCompania == "S" || confirmarCompania == "s")
                    {
                       Console.WriteLine("Ingrese el nuevo nombre de la compañia (Max 40 dígitos):");
                        compania = Console.ReadLine();

                        if(compania.Length > 40)
                        {
                            Console.WriteLine("El nombre de la compañia no puede tener más de 40 caracteres.");
                            return;
                        }
                    }

                    customerLogic.Update(new CustomersDTO
                    {
                        CustomerID = customerDTO.CustomerID,
                        CompanyName = compania,
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
                catch (Exception ex)
                {
                    Console.WriteLine("Se produjo un error al modificar el cliente: " + ex.Message);
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
