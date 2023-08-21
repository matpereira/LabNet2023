using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ej4CustomException;

namespace Ej4CustomException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomException();
        }

        private static void CustomException()
        {
            try
            {
                Logic.ThrowCustomException();
            }
            catch (CustomException e)
            {
                Console.WriteLine($" Excepcion capturada \n { e.Message}");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
