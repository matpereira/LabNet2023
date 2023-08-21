using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2.Exceptions
{
    internal class DivExceptions
    {
        public static void DivisionPorCero()
        {
            try
            {
                Console.WriteLine("Introduce el numero que sera dividido por cero");
                int dividendo = int.Parse(Console.ReadLine());
                int resultado = dividendo / 0;
 
                Console.WriteLine($"El resultado es:{resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"No se puede dividir por cero \nMensaje de la Excepcion : {ex.Message}");
              
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"El valor introducido no es un número \nMensaje de la Excepcion : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Fin del programa");
                Console.ReadLine();
            }
        }

        public static void DivisionDosNum()
        {

            try
            {
                Console.WriteLine("Introduce el numero que sera dividido");
                int dividendo = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduce el numero que sera divisor");
                int divisor = int.Parse(Console.ReadLine());
                int resultado = dividendo / divisor;

                Console.WriteLine($"El resultado es:{resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("¡Solo Chuck Norris divide por cero!");
                Console.WriteLine("\nMensaje de la Excepcion : {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"¡Error! {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Fin del programa");
                Console.ReadLine();
            }
        }

    }
}
