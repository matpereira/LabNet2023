using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjLogic;

namespace EjLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LogicException();
        }

        private static void LogicException()
        {
            try
            {
               Logic.ThrowException();
            }
            catch (Exception ex)
            {
            Console.WriteLine($"Mensaje de la excepcion: {ex.Message}");
            Console.WriteLine($"Tipo de excepcion: {ex.GetType().ToString()}");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
