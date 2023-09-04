using System.Collections.Generic;
using System.Linq;
using LinQ.Entities;

namespace LinQ.Logic
{
    public class ProductsLogic : BaseLogic
    {

        public List<Products> ObtenerProductosSinStock()
        {
            var productosSinStock = context.Products.Where(p => p.UnitsInStock == 0).ToList();
            return productosSinStock;
        }

        public List<Products> ObtenerProductosConMasDeTresStock()
        {
            var productos = context.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3).ToList();
            return productos;
        }

        public Products ObtenerProductoPorID(int productID)
        {
            var producto = (from prod in context.Products
                            where prod.ProductID == productID
                            select prod).FirstOrDefault();

            return producto;
        }

        public List<Products> ObtenerProductosOrdenadosPorNombre()
        {
            var productosOrdenadosPorNombre = context.Products.OrderBy(p => p.ProductName).ToList();
            return productosOrdenadosPorNombre;
        }

        public List<Products> ObtenerProductosOrdenadosPorMayorStock()
        {
            var productosOrdenadosPorMayorStock = context.Products.OrderByDescending(p => p.UnitsInStock).ToList();
            return productosOrdenadosPorMayorStock;
        }

        public List<string> ObtenerCategoriasDistintas()
        {
            var categoriasDistintas = (from prod in context.Products
                                       select prod.Categories.CategoryName).Distinct().ToList();

            return categoriasDistintas;
        }

        public Products ObtenerPrimerProducto()
        {
            var primerProducto = context.Products.FirstOrDefault();
            return primerProducto;
        }
    }
}

