using System;

namespace Div2Numeros.Exceptions
{
    public class DivExceptions
    {
        public static double DivisionDosNum()
        {
            try
            {   
                Console.WriteLine("Introduce el numero que sera dividido");
                double dividendo = double.Parse(Console.ReadLine());
                Console.WriteLine("Introduce el numero que sera divisor");
                double divisor = double.Parse(Console.ReadLine());
                if(divisor==0)
                {
                    throw new DivideByZeroException();
                }
                double resultado = dividendo / divisor;
                Console.WriteLine($"El resultado es:{resultado}");
                return resultado;
            }
            catch (DivideByZeroException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡CUIDADO!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Si este programa lo utiliza Chuck Norris y divide por cero en una computadora, esta explota y se convierte en una mini supernova.");
                throw ex;
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
                throw ex;
            }
            finally
            {
                Console.WriteLine("Fin del programa");
            }
        }
    }
}
