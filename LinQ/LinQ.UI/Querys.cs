using System;
using System.Collections.Generic;
using LinQ.Entities;
using LinQ.UI;

namespace LinQ.Logic
{
    public class Querys
    {
        public static void ConsultarCustomer(string id)
        {
            CustomerLogic customerLogic = new CustomerLogic();
            var customer = customerLogic.ObtenerCustomerPorId(id);

            if (customer != null)
            {
                Console.WriteLine("Customer seleccionado:\n");
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
        }

        public static void CustomersWA()
        {
            var customersLogic = new CustomerLogic();
            var customerWA = customersLogic.ObtenerCustomersWA();
            Console.Clear();
            if (customerWA != null)
            {
                Console.WriteLine("Clientes de la región WA:");
                foreach (var customer in customerWA)
                {
                    UI.UIFunctions.MostrarCustomer(customer);
                }
            }
            else
            {
                Console.WriteLine("No hay clientes de la región WA");
            }
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
        }

        public static void CustomerMayusMinus()
        {
            var customersLogic = new CustomerLogic();
            var customers = customersLogic.ObtenerCustomerMayusMinus();
            Console.Clear();
            if(customers != null)
            {
                Console.WriteLine("Clientes con nombre en mayúscula y minúscula:");
                foreach (var customer in customers)
                {
                    Console.WriteLine($"{customer}");
                }
            }
            else
            {
                Console.WriteLine("No hay customers cargados");
            }
        }

        public static void JoinCustomersOrders()
        {
            var customersLogic = new CustomerLogic();
            var clientesYOrdenesWA = customersLogic.ObtenerCustomersYOrders();
            Console.Clear();
            if(clientesYOrdenesWA!= null)
            {
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
            else
            {
                Console.WriteLine("No hay clientes de la región WA con ordenes posteriores al 1 de enero de 1997");
            }
        }

        public static void PrimerosTresCustomerWA()
        {             
            var customersLogic = new CustomerLogic();
            var primerosTresCustomerWA = customersLogic.ObtenerPrimerosTresCustomerWA();
            Console.Clear();
        if (primerosTresCustomerWA != null)
            {
                Console.WriteLine("Primeros 3 clientes de la región WA:");
                foreach (var customer in primerosTresCustomerWA)
                {
                  UI.UIFunctions.MostrarCustomer(customer);
                }
            }
            else
            {
                Console.WriteLine("No hay clientes de la región WA");
            }             
        }

        public static void ProductosOrdenadosPorNombre()
        {
            var productsLogic = new ProductsLogic();
            List <Products> productosOrdenadosPorNombre = productsLogic.ObtenerProductosOrdenadosPorNombre();
            Console.Clear();
            UIFunctions.ValidarListaProductos(productosOrdenadosPorNombre);
        }

        public static void ProductosOrdenadosPorMayorStock()
        {
            var productsLogic = new ProductsLogic();
            List<Products> productosOrdenadosPorMayorStock = productsLogic.ObtenerProductosOrdenadosPorMayorStock();
            Console.Clear();
            UIFunctions.ValidarListaProductos(productosOrdenadosPorMayorStock);
        }

        public static void CategoriasAsociadasAProductos()
        {
            var productsLogic = new ProductsLogic();
            var categoriasAsociadasAProductos = productsLogic.ObtenerCategoriasDistintas();
            Console.Clear();
            Console.WriteLine("Categorías distintas asociadas a productos:");
            foreach (var categoria in categoriasAsociadasAProductos)
            {
                Console.WriteLine(categoria);
            }
        }

        public static void PrimerProducto()
        {             
            var productsLogic = new ProductsLogic();
            var primerProducto = productsLogic.ObtenerPrimerProducto();
            Console.Clear();
            if(primerProducto != null)
            {
                Console.WriteLine("Primer producto:");
                UI.UIFunctions.MostrarProducto(primerProducto);
            }
            else
            {
                Console.WriteLine("No hay productos");
            }
        }


        public static void JoindClientesCantOrdenes()
        {
            var customersLogic = new CustomerLogic();
            var clientesConOrdenes = customersLogic.ObtenerCustomersConCantidadDeOrdenes();

            Console.WriteLine("Clientes con cantidad de órdenes asociadas:");
            foreach (var resultado in clientesConOrdenes)
            {
                Console.WriteLine($"CustomerID: {resultado.Customer.CustomerID}");
                Console.WriteLine($"CompanyName: {resultado.Customer.CompanyName}");
                Console.WriteLine($"OrderCount: {resultado.OrderCount}");
                Console.WriteLine();
            }
        }

    }
}
