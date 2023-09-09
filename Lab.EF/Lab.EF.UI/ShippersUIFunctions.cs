using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab.EF.UI.Shippers
{
    public class ShippersUIFunctions
    {
        public static void ObtenerShippers(ShippersLogic shipperLogic)
        {
            Console.WriteLine("ID\t|\tNombre de la compañia\t|\tTelefono");

            var shippers = shipperLogic.GetAll().Select(shipper => new ShippersDTO
            {
                ShipperID = shipper.ShipperID,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            }).ToList();

            foreach (var shipper in shippers)
            {
                var companyName = shipper.CompanyName.Length <= 16 ? shipper.CompanyName + "\t\t\t" : shipper.CompanyName;
                Console.WriteLine($"{shipper.ShipperID}\t|\t{companyName}\t|\t{shipper.Phone}");
            }
        }


        public static void NuevoShipper(ShippersLogic shipperLogic)
        {
            var nombre = UIFunctions.LeerCadenaConLongitudMaxima("Ingrese el nombre de la compañia (máximo 40 caracteres):", 40);

            Console.WriteLine("Ingrese numero de telefono (Max 24 digitos):");
            var numeroTelefono = Console.ReadLine();

            if (UIFunctions.EsNumeroTelefonoValido(numeroTelefono))
            {
                shipperLogic.Add(new ShippersDTO
                {
                    CompanyName = nombre,
                    Phone = numeroTelefono
                });
            }
            else
            {
                Console.WriteLine("Número de teléfono no válido.");
            }
        }

        public static void ModificarShipper(ShippersLogic shipperLogic)
        {
            Console.WriteLine("Ingrese el ID a modificar:");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                var shipperDTO = shipperLogic.Find(id);

                if (shipperDTO != null)
                {
                    Console.WriteLine("Modificar el nombre de la compañia? (S/N)");
                    var confirmar = Console.ReadLine();
                    string nombreCompania = confirmar == "S" || confirmar == "s"
                        ? UIFunctions.LeerCadenaConLongitudMaxima("Ingrese el nuevo nombre de la compañia (máximo 40 caracteres):", 40)
                        : shipperDTO.CompanyName;

                    Console.WriteLine("Modificar el número de telefono? (S/N)");
                    confirmar = Console.ReadLine();
                    string nuevoTelefono = confirmar == "S" || confirmar == "s"
                        ? UIFunctions.LeerCadenaConLongitudMaxima("Ingrese el nuevo número de telefono (Max 24 dígitos):", 24)
                        : shipperDTO.Phone;

                    if (UIFunctions.EsNumeroTelefonoValido(nuevoTelefono))
                    {
                        shipperLogic.Update(new ShippersDTO
                        {
                            ShipperID = id,
                            CompanyName = nombreCompania,
                            Phone = nuevoTelefono
                        });
                        Console.WriteLine("Shipper actualizado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Número de teléfono no válido.");
                    }
                }
                else
                {
                    Console.WriteLine("El ID ingresado no existe.");
                }
            }
            else
            {
                Console.WriteLine("Solo se aceptan números para el ID.");
            }
        }

        public static void BorrarShipper(ShippersLogic shipperLogic)
        {
            Console.Clear();
            Console.WriteLine("Selecciona el ID a eliminar:");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                var shipperDTO = shipperLogic.Find(id);

                if (shipperDTO != null)
                {
                    Console.WriteLine("¿Está seguro que desea eliminar el registro? ");
                    Console.WriteLine("Escriba S para confirmar u otra letra para cancelar");
                    var confirmacion = Console.ReadLine();
                    if (confirmacion == "S" || confirmacion == "s")
                    {
                        shipperLogic.Delete(id);
                        Console.WriteLine("Shipper eliminado exitosamente.");
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
                Console.WriteLine("Solo se aceptan números para el ID.");
            }
        }
    }
}
