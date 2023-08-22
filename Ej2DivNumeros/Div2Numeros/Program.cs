using System;
using Div2Numeros.Exceptions;

namespace Div2Numeros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Try-Catch para capturar la excepcion y poder realizar las pruebas unitarias
            try
            {
                DivExceptions.DivisionDosNum();
            } 
            catch (Exception ex) 
            {
                Console.WriteLine($"Mensaje de la Excepcion : {ex.Message}");
            }
            Console.ReadLine();
            
        }
    }
}
