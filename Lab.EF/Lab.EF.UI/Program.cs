using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Security.Policy;
using Lab.EF.Entities;
using Lab.EF.Logic;

namespace Lab.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int seleccion;
            int borrar;
            UIFunctions uiFunctions = new UIFunctions();
            ShippersLogic shipperLogic = new ShippersLogic();
            CustomersLogic customersLogic = new CustomersLogic();
            do
            {
                uiFunctions.mostrarMenu();
                // Leer la opción del usuario
                if (int.TryParse(Console.ReadLine(), out seleccion))
                {
                    switch (seleccion)
                    {
                        case 1:
                            NuevoShipper(shipperLogic);
                            break;
                        case 2:
                            ModificarShipper(shipperLogic);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Selecciona el id a eliminar");
                            if (int.TryParse(Console.ReadLine(), out borrar))
                                shipperLogic.Delete(borrar);
                            else
                            {
                                Console.WriteLine("Entrada no válida. Intente nuevamente.");
                            }
                            break;
                        case 4:
                            Console.Clear();
                            uiFunctions.ObtenerShippers(shipperLogic);
                            break;
                        case 5:
                            Console.Clear();
                            uiFunctions.ObtenerCustomers(customersLogic);
                            break;
                        case 0:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente nuevamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, seleccione un digito.");
                }
               Console.WriteLine(); 
            } while (seleccion != 0);


            Console.ReadLine();
        }


        public static void NuevoShipper(ShippersLogic shipperLogic)
        {
            UIFunctions uiLogic = new UIFunctions();
            Console.WriteLine("Ingrese el nombre de la compañia");
            var nombre = Console.ReadLine();
            Console.WriteLine("Ingrese numero de telefono formato Argentina (codigo de area obligatorio)");
            var numeroTelefono = Console.ReadLine();

            if (uiLogic.EsNumeroTelefonoValido(numeroTelefono))
            {
                shipperLogic.Add(new Shippers
               {
                    CompanyName = nombre,
                    Phone = numeroTelefono
                });
            }
        }


        public static void ModificarShipper(ShippersLogic shipperLogic)
        {
            UIFunctions uiLogic = new UIFunctions();
            Console.WriteLine("Ingrese el id a modificar");
            int id;

            if (int.TryParse(Console.ReadLine(), out id))
            {
                if (shipperLogic.Find(id) != 0)
                {
                    Console.WriteLine("Ingrese el nombre de la compañia");
                    var nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese numero de telefono formato Argentina (codigo de area obligatorio)");
                    var numeroTelefono = Console.ReadLine();

                    if (uiLogic.EsNumeroTelefonoValido(numeroTelefono))
                    {
                        shipperLogic.Update(new Shippers
                        {
                            ShipperID = id,
                            CompanyName = nombre,
                            Phone = numeroTelefono
                        });
                    }
                }
                else
                {
                    Console.WriteLine("El id ingresado no existe");
                }
            }
            else
            {
                Console.WriteLine("solo se aceptan numeros para el ID");
            }


        }



    }

}

