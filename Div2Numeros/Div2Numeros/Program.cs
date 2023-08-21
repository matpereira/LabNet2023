using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Div2Numeros.Exceptions;

namespace Div2Numeros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DivExceptions.DivisionDosNum();
            } 
            catch (Exception ex) 
            {
                Console.WriteLine($"Mensaje de la Excepcion : {ex.Message}");
                Console.ReadLine();

            }
        }
    }
}
