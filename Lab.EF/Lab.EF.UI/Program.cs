using System;
using Lab.EF.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Lab.EF.Entities;

namespace Lab.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShippersLogic ShipperLogic = new ShippersLogic();
            CustomersLogic customerLogic = new CustomersLogic();


            foreach (var shipper in ShipperLogic.GetAll())
            {
                Console.WriteLine($"{shipper.CompanyName}");
            }

            foreach (var customer in customerLogic.GetAll())
            {
                Console.WriteLine($"{customer.CompanyName}");
            }
            Console.ReadLine();
        }
    }
}
