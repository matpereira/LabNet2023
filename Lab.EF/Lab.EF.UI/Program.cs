using System;
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
            uiFunctions.MostrarMenu();
            if (int.TryParse(Console.ReadLine(), out seleccion))
            {
                switch (seleccion)
                {
                    case 1:
                        uiFunctions.NuevoShipper(shipperLogic);
                        break;
                    case 2:
                        uiFunctions.ModificarShipper(shipperLogic);
                        break;
                    case 3:
                        uiFunctions.BorrarShipper(shipperLogic);
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


}


}


