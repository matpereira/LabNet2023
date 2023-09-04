using System;
using LinQ.Logic;
using LinQ.Entities;
using LinQ.Data;



namespace LinQ.UI
{
    public class UIFunctions
    {
        public static void MostrarMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Mostrar customer");//ok
            Console.WriteLine("2. Todos los productos sin stock");
            Console.WriteLine("3. Todos los productos que tienen stock y que cuestan más de 3 por nunidad");
            Console.WriteLine("4. Todos los customers de la Región WA");
            Console.WriteLine("5. Primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
            Console.WriteLine("6. Nombre de todos los Customers, mayuscula y minuscula");
            Console.WriteLine("7. Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997");
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
    }

}




