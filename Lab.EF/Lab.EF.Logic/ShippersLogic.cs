using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class ShippersLogic
    {
        private readonly NorthwindContext context;

        public ShippersLogic()
        {
            context = new NorthwindContext();
        }

        public  List<Shippers> GetAll()
        {
            return context.Shippers.ToList();
        }
    }
}
