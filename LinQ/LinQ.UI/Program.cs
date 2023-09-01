using System;
using System.Data.Entity;
using System.Linq;
using LinQ.Data;
using LinQ.Entities;
using LinQ.Logic;
 
namespace LinQ.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int seleccion;
            /*  do
              {
                  // Leer la opción del usuario
                  if (int.TryParse(Console.ReadLine(), out seleccion))
                  {
                      switch (seleccion)
                      {
                          case 1:
                              Console.Clear();
                              break;
                          case 2:
                              Console.Clear();
                              break;
                          case 3:
                              Console.Clear();
                              break;
                          case 4:
                              Console.Clear();
                              break;
                          case 5:
                              Console.Clear();
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
            */

          //  Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LinQDb>());

            var db = new NorthwindContext();

            var query = from customer in db.Customers
                        orderby customer.CustomerID
                        select customer;

            foreach (var customer in query)
            {
                Console.WriteLine($"CustomerID: {customer.CustomerID}");
            }
            
            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadLine();
        }

    }
}
