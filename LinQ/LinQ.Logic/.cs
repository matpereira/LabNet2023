using LinQ.Entities;
using System.Data.Entity;


namespace LinQ.Logic
{
    public class LinQDb : DbContext
    {

        public DbSet<Customers> Customers { get; set; }
    }
}
