using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div2Numeros.Exceptions
{
    public class DivExceptions
    {

        public static int DivisionDosNum()
        {

            try
            {
                Console.WriteLine("Introduce el numero que sera dividido");
                int dividendo = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduce el numero que sera divisor");
                int divisor = int.Parse(Console.ReadLine());

                int resultado = dividendo / divisor;


                Console.WriteLine($"El resultado es:{resultado}");
                return resultado;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("¡Solo Chuck Norris divide por cero!");
                Console.WriteLine("\nMensaje de la Excepcion : {ex.Message}");
                throw ex;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
                throw ex;
            }
            finally
            {
                Console.WriteLine("Fin del programa");
                Console.ReadLine();
            }
        }
    }
}
