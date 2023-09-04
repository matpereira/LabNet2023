using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using LinQ.Entities;

namespace LinQ.Logic
{
    public class ProductsLogic: BaseLogic
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

        public Products ObtenerProductoPorID(int productoID)
        {
            var producto = (from p in context.Products
                            where p.ProductID == productoID
                            select p).FirstOrDefault();

            return producto;
        }
    }
}

