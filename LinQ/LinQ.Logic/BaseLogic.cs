using LinQ.Data;

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
