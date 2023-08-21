using labNetPractica2.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           DivExceptions.DivisionPorCero();
            // DivExceptions.DivisionDosNum();
            // LogicException();


        }

        private static void LogicException()
        {
            try
            {
                Logic.ThrowException();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se capturó una excepción:");
                Console.WriteLine("Tipo de excepción: " + ex.GetType());
                Console.WriteLine("Mensaje de excepción: " + ex.Message);

            }
            finally
            {
                Console.ReadLine();
            }

        }

       

    }
}
