using System;
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
                            BorrarShipper(shipperLogic);
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
                            Console.ForegroundColor = ConsoleColor.Magenta;
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


        private static void NuevoShipper(ShippersLogic shipperLogic)
        {
            UIFunctions uiFunction = new UIFunctions();
      
            
                Console.WriteLine("Ingrese el nombre de la compañia");
                var nombre = Console.ReadLine();
                while(nombre.Length>40)
                  {  
                Console.Clear();
                     Console.WriteLine("El nombre dela compania no puede superar los 40 caracteres");
                     Console.WriteLine("por favor ingrese nuevamente el nombre de la compania");
                     nombre = Console.ReadLine();
                   }
                  Console.WriteLine("Ingrese numero de telefono formato Argentina ");
                var numeroTelefono = Console.ReadLine();

                if (uiFunction.EsNumeroTelefonoValido(numeroTelefono))
                {
                    shipperLogic.Add(new Shippers
                    {
                        CompanyName = nombre,
                        Phone = numeroTelefono
                    });
                }
            
        }


        private static void ModificarShipper(ShippersLogic shipperLogic)
        {
            UIFunctions uiFunction = new UIFunctions();
            Console.WriteLine("Ingrese el id a modificar");
            int id;
            string nombreCompania;

            if (int.TryParse(Console.ReadLine(), out id))
            {
                if (shipperLogic.Find(id) != 0)
                {
                    Console.WriteLine("Modificar el nombre de la compañia? (S/N)");
                    var confirmar = Console.ReadLine();
                    if(confirmar == "S" || confirmar == "s")
                    {
                        Console.WriteLine("Ingrese el nombre de la compañia");
                        nombreCompania = Console.ReadLine();
                        while (nombreCompania.Length > 40)
                        {
                            Console.Clear();
                            Console.WriteLine("El nombre de la compania no puede superar los 40 caracteres");
                            Console.WriteLine("por favor ingrese nuevamente el nombre de la compania");
                            nombreCompania = Console.ReadLine();
                        }
                    }
                    else
                    {
                     //no lo veo eficiente ya que tengo que volver a leer la base de datos
                     //para obtener el nombre de la compania si paso por aqui

                        nombreCompania = shipperLogic.GetAll().Find(x => x.ShipperID == id).CompanyName;
                    }
                        

                    Console.WriteLine("Modificar el numero de telefono?");
                    confirmar = Console.ReadLine();
                    if (confirmar == "S" || confirmar == "s")
                    {
                        Console.WriteLine("Ingrese numero de telefono (Max 24 digitos)");
                        var numeroTelefono = Console.ReadLine();
                        if (uiFunction.EsNumeroTelefonoValido(numeroTelefono))
                        {
                            shipperLogic.Update(new Shippers
                            {
                                ShipperID = id,
                                CompanyName = nombreCompania,
                                Phone = numeroTelefono
                            });
                        }
                    }
                    else
                    {
                        //no lo veo eficiente ya que tengo que volver a leer la base de datos
                        //para obtener el telefono de la compania si paso por aqui
                        shipperLogic.Update(new Shippers
                        {
                            ShipperID = id,
                            CompanyName = nombreCompania,
                            Phone = shipperLogic.GetAll().Find(x => x.ShipperID == id).Phone
                    }) ;
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

        private static void BorrarShipper(ShippersLogic shipperLogic)
        {
            UIFunctions uiFunction = new UIFunctions();
            Console.Clear();
            Console.WriteLine("Selecciona el id a eliminar");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                if (shipperLogic.Find(id) != 0)
                {
                    Console.WriteLine("Esta seguro que desea eliminar el registro? (S/N)");
                    var confirmacion = Console.ReadLine();
                    if (confirmacion == "S" || confirmacion == "s")
                    {
                        shipperLogic.Delete(id);
                    }
                }
            }
            else
            {
                Console.WriteLine("solo se aceptan numeros para el ID");
            }
        }

    }

}

