using System;
using LinQ.Logic;
using LinQ.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LinQ.UI
{
    public class UIFunctions
    {
        public static void MostrarMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Mostrar customer");
            Console.WriteLine("2. Todos los productos sin stock");
            Console.WriteLine("3. Todos los productos que tienen stock y que cuestan más de 3 por nunidad");
            Console.WriteLine("4. Todos los customers de la Región WA");
            Console.WriteLine("5. Primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
            Console.WriteLine("6. Nombre de todos los Customers, mayuscula y minuscula");
            Console.WriteLine("7. Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997");
            Console.WriteLine("8. Los primeros 3 customers de la Región WA");
            Console.WriteLine("9. Lista de productos orddenados por nombre");
            Console.WriteLine("10. Lista de productos ordenados por mayor stock");
            Console.WriteLine("11. Consultar las distintas categorías asociadas a los productos");
            Console.WriteLine("12. Consultar el primer elemento de una lista de productos");
            Console.WriteLine("13. Consultar customers y la cantidad de ordenes asociadas");
            Console.WriteLine("0. Salir");
            Console.WriteLine();
            Console.WriteLine("Seleccione una opción: ");
        }

        public static void SeleccionarCustomer()
        {
            Console.WriteLine("Escribir el Id del customer deseado");
            var id= Console.ReadLine();

            while(id.Length != 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error:");
                Console.WriteLine("El id es de longitud fija por lo tanto debe tener 5 caracteres");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Escribir el Id del customer deseado");
                id = Console.ReadLine();
            }
            Console.Clear();
            Querys.ConsultarCustomer(id);

        }

        public static void MostrarProducto(Products producto)
        {
            Console.WriteLine($"Product ID: {producto.ProductID}");
            Console.WriteLine($"Product Name: {producto.ProductName}");
            Console.WriteLine($"Supplier ID: {producto.SupplierID}");
            Console.WriteLine($"Category ID: {producto.CategoryID}");
            Console.WriteLine($"Quantity Per Unit: {producto.QuantityPerUnit}");
            Console.WriteLine($"Unit Price: {producto.UnitPrice}");
            Console.WriteLine($"Units In Stock: {producto.UnitsInStock}");
            Console.WriteLine($"Units On Order: {producto.UnitsOnOrder}");
            Console.WriteLine($"Reorder Level: {producto.ReorderLevel}");
            Console.WriteLine($"Discontinued: {producto.Discontinued}");
            Console.WriteLine();
        }

        public static void ValidarListaProductos(List<Products> productos )
        {
            if(productos.Count==0)
            {
                Console.WriteLine("No hay productos cargados");
            }
            else
            {
                foreach (var producto in productos)
                {
                    MostrarProducto(producto);
                }

            }
        }

        public static void ValidarListaProductos(IQueryable<Products> productos)
        {
            if (productos == null)
            {
                Console.WriteLine("No hay productos cargados");
            }
            else
            {
                foreach (var producto in productos)
                {
                    MostrarProducto(producto);
                }
            }
        }


        public static void MostrarCustomer(Customers customer)
        {
            Console.WriteLine($"Customer ID: {customer.CustomerID}");
            Console.WriteLine($"Company Name: {customer.CompanyName}");
            Console.WriteLine($"Contact Name: {customer.ContactName}");
            Console.WriteLine($"Contact Title: {customer.ContactTitle}");
            Console.WriteLine($"Address: {customer.Address}");
            Console.WriteLine($"City: {customer.City}");
            Console.WriteLine($"Region: {customer.Region}");
            Console.WriteLine($"Postal Code: {customer.PostalCode}");
            Console.WriteLine($"Country: {customer.Country}");
            Console.WriteLine($"Phone: {customer.Phone}");
            Console.WriteLine($"Fax: {customer.Fax}");
            Console.WriteLine();
        }

        public static void PresioneUnaTeclaParaSalir()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Cuando es tu primer dia de trabajo y se te olvida poner el WHERE en el DELETE FROM");
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("                             __\r\n                   _ ,___,-'\",-=-.\r\n       __,-- _ _,-'_)_  (\"\"`'-._\\ `.\r\n    _,'  __ |,' ,-' __)  ,-     /. |\r\n  ,'_,--'   |     -'  _)/         `\\\r\n,','      ,'       ,-'_,`           :\r\n,'     ,-'       ,(,-(              :\r\n     ,'       ,-' ,    _            ;\r\n    /        ,-._/`---'            /\r\n   /        (____)(----. )       ,'\r\n  /         (      `.__,     /\\ /,\r\n :           ;-.___         /__\\/|\r\n |         ,'      `--.      -,\\ |\r\n :        /            \\    .__/\r\n  \\      (__            \\    |_\r\n   \\       ,`-, *       /   _|,\\\r\n    \\    ,'   `-.     ,'_,-'    \\\r\n   (_\\,-'    ,'\\\")--,'-'       __\\\r\n    \\       /  // ,'|      ,--'  `-.\r\n     `-.    `-/ \\'  |   _,'         `.\r\n        `-._ /      `--'/             \\\r\n           ,'           |              \\\r\n          /             |               \\\r\n       ,-'              |               /\r\n      /                 |             -'");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("       /  Fue un placer \\\r\n       \\  trabajar aqui /    \r\n                     __\r\n            O      _//\\-\\\r\n             O    /      \\\r\n              o  /       |\r\n               (.(.) /|\\/\r\n                (___    ,)\r\n                /   \\   \\\r\n     _          \\o  /   |\r\n   _( \\_         _| _____\\\r\n  (___  \\_______/\\_/______\\\r\n  (___         /    /    \\|\r\n  (___________/     |____||\r\n             /      |    ||\r\n            /_______|    |_\\\r\n            \\      _|    | /\r\n             |    (_     \\/\r\n             | \\__  | | | |\r\n             |    \\ |_|_|_|\r\n             |     |     |\r\n             |     |     |\r\n             |     |     |\r\n             |_____|_____|\r\n             |_____|_____|\r\n            /_____//_____|");
       
        }



    }

}




