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
                double dividendo = double.Parse(Console.ReadLine());
                double resultado = dividendo / 0;
 
                Console.WriteLine($"El resultado es:{resultado}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("No se puede dividir por cero");
            }
            catch (FormatException)
            {
                Console.WriteLine("El valor introducido no es un número");
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
                double dividendo = double.Parse(Console.ReadLine());
                Console.WriteLine("Introduce el numero que sera divisor");
                double divisor = double.Parse(Console.ReadLine());
                double resultado = dividendo / divisor;

                Console.WriteLine($"El resultado es:{resultado}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("¡Solo Chuck Norris divide por cero!");
                Console.WriteLine("¡No se puede dividir por cero!");
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
