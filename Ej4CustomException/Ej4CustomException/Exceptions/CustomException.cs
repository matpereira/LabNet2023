using System;

namespace Ej4CustomException
{
    internal class CustomException: Exception
    {
        public static void Custom()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Logic.ThrowCustomException();
            }
            catch (CustomException e)
            {
                Console.WriteLine($" Excepcion capturada \n {e.Message}");
            }
            finally
            {
                Console.ReadLine();
            }
        }
        public CustomException(string mensajeCustom) : base($"Mensaje de la excepcion: {mensajeCustom}")
        {
        }
    }
}
