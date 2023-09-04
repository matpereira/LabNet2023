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
            int seleccion;
            do
              {
                  UIFunctions.MostrarMenu();
                  if (int.TryParse(Console.ReadLine(), out seleccion))
                  {
                      switch (seleccion)
                      {
                          case 1:
                            UIFunctions.SeleccionarCustomer();
                            break;
                          case 2:
                            Querys.ProductosSinStock();
                              break;
                          case 3:
                            Querys.StockMasDeTres();
                              break;
                          case 4:
                            Querys.CustomersWA();
                              break;
                          case 5:
                            Querys.ObtenerProductoPorID();
                              break;
                          case 6:
                            Querys.CustomerMayusMinus();
                            break;
                          case 7:
                            Querys.JoinCustomersOrders();
                            break;
                          case 8:
                            Querys.PrimerosTresCustomerWA();
                            break;
                          case 9:
                            Querys.ProductosOrdenadosPorNombre();
                            break;
                          case 10:
                            Querys.ProductosOrdenadosPorMayorStock();
                            break;
                          case 11:
                            Querys.CategoriasAsociadasAProductos();
                            break;
                          case 12:
                            Querys.PrimerProducto();
                            break;
                          case 13:
                            Querys.JoindClientesCantOrdenes();
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
            } while (seleccion != 0);
         
            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadLine();
        }

    }
}
