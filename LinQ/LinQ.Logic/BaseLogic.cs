using LinQ.Data;
using System.Data.Entity;
using System.Linq;

namespace LinQ.Logic
{
    public class BaseLogic
    {
        protected readonly NorthwindContext context;
        public BaseLogic()
        {
            context = new NorthwindContext();
        }

        

    }
}
