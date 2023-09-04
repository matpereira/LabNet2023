using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using LinQ.Entities;
using LinQ.Data;
using LinQ.Logic;
using LinQ.UI;
using System.Net.NetworkInformation;

namespace LinQ.Logic
{
    public class Querys
    {
        public static void ConsultarCustomer(string id)
        {
            //  var customer = context.Customers.FirstOrDefault(c => c.CustomerID == id.ToString());
            CustomerLogic customerLogic = new CustomerLogic();
            var customer = customerLogic.ObtenerCustomerPorId(id);

            if (customer != null)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerID}");
                Console.WriteLine($"Company Name: {customer.CompanyName}");
                Console.WriteLine($"Contact Title: {customer.ContactTitle}");
                Console.WriteLine($"Address: {customer.Address}");
                Console.WriteLine($"City: {customer.City}");
                Console.WriteLine($"Region: {customer.Region}");
                Console.WriteLine($"PostalCode: {customer.PostalCode}");
                Console.WriteLine($"Country: {customer.Country}");
                Console.WriteLine($"Phone: {customer.Phone}");
                Console.WriteLine($"Fax: {customer.Fax}");
            }
            else
            {
                Console.WriteLine("Customer no encontrado");
            }
            Console.ReadLine();
        }

        public static void ProductosSinStock()
        {     
            ProductsLogic productsLogic = new ProductsLogic();
            List<Products> productosSinStock = productsLogic.ObtenerProductosSinStock();
            Console.WriteLine();
            Console.Clear();
            if (productosSinStock.Count == 0)
            {
                Console.WriteLine("No hay productos sin stock");
            }
            else
            {
                Console.WriteLine($"Cantidad de productos sin stock: {productosSinStock.Count}");
                Console.WriteLine();
                foreach (var producto in productosSinStock)
                {
                    UIFunctions.MostrarProducto(producto);

                }
            }
            Console.ReadLine();

        }

        public static void StockMasDeTres()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            List<Products> productosMasDeTres = productsLogic.ObtenerProductosConMasDeTresStock();
            Console.WriteLine();
            Console.Clear();
            if (productosMasDeTres.Count == 0)
            {
                Console.WriteLine("No hay productos con stock mayor a 3");
            }
            else
            {
                Console.WriteLine($"Cantidad de productos con stock y precio mayor a 3 c/u: {productosMasDeTres.Count}");
                Console.WriteLine();
                foreach (var producto in productosMasDeTres)
                {
                    UIFunctions.MostrarProducto(producto);
                }
            }
            Console.ReadLine();

        }

        public static void CustomersWA()
        {
            var customersLogic = new CustomerLogic();
            var customerWA = customersLogic.ObtenerCustomersWA();
            Console.Clear();
            Console.WriteLine("Clientes de la región WA:");
            foreach (var customer in customerWA)
            {
                UI.UIFunctions.MostrarCustomer(customer);
            }
            Console.ReadLine();

        }

        public static void ObtenerProductoPorID()
        {
            var productsLogic = new ProductsLogic();
            int id = 789;
            var producto = productsLogic.ObtenerProductoPorID(id);
            Console.Clear();
            if (producto != null)
            {
              UIFunctions.MostrarProducto(producto);
            }
            else
            {
                Console.WriteLine("Producto no encontrado");
            }
            Console.ReadLine();

        }

        public static void CustomerMayusMinus()
        {
            var customersLogic = new CustomerLogic();
            var customers = customersLogic.ObtenerCustomerMayusMinus();
            Console.Clear();
            Console.WriteLine("Clientes con nombre en mayúscula y minúscula:");

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer}");
            }
            Console.ReadLine();

        }

        public static void JoinCustomersOrders()
        {
            var customersLogic = new CustomerLogic();
            var clientesYOrdenesWA = customersLogic.ObtenerClientesYOrdenes();

            Console.WriteLine("Customer WA y Orden posteriores al 1 de enero de 1997:");
            foreach (var clienteOrden in clientesYOrdenesWA)
            {
                Console.WriteLine($"Customer ID: {clienteOrden.CustomerID}");
                Console.WriteLine($"Company Name: {clienteOrden.CompanyName}");
                Console.WriteLine($"OrderID: {clienteOrden.OrderID}");
                Console.WriteLine($"OrderDate: {clienteOrden.OrderDate}");
                Console.WriteLine();
            }
        }


    }
}
