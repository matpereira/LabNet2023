using LinQ.Entities;
using System.Collections.Generic;
using System.Linq;


namespace LinQ.Logic
{
    public class CustomersLogic : BaseLogic
    {

        public  List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }
    }
}
