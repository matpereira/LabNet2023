using System;

namespace EjLogic
{
    internal class Logic
    {
        public static void LogicException()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            try
            {
                ThrowException();
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

        private static void ThrowException()
        {
            throw new Exception("Excepcion de prueba!");
        }



    }
}
