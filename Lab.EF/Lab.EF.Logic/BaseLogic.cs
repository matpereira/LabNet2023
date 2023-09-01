using Lab.EF.Data;


namespace Lab.EF.Logic
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
