using Lab.EF.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Lab.EF.Logic
{
    public class CustomersLogic : BaseLogic
    {

        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }
    }
}
