using System;
using Lab.EF.Logic;
using Lab.EF.UI.Customers;
using Lab.EF.UI.Shippers;

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
                            ShippersUIFunctions.NuevoShipper(shipperLogic);
                        break;
                    case 2:
                            ShippersUIFunctions.ModificarShipper(shipperLogic);
                        break;
                    case 3:
                            ShippersUIFunctions.BorrarShipper(shipperLogic);
                        break;
                    case 4:
                        Console.Clear();
                            ShippersUIFunctions.ObtenerShippers(shipperLogic);
                        break;
                    case 5:
                            CustomersUIFunctions.NuevoCustomer(customersLogic);
                        break;
                    case 6:
                            CustomersUIFunctions.ModificarCustomer(customersLogic);
                        break;
                    case 7:
                            CustomersUIFunctions.BorrarCustomer(customersLogic);
                        break;
                    case 8:
                        Console.Clear();
                            CustomersUIFunctions.ObtenerCustomers(customersLogic);
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


