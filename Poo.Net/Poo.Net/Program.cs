using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            int cant;
            int taxiNumero = 1;
            int omnibusNumero = 1;
            bool esEnteroValido;

            List<Taxi> taxis = new List<Taxi>();
            List<Omnibus> omnibuses = new List<Omnibus>();

            List<TransportePublico> transportes = new List<TransportePublico>();


            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Ingresa la cantidad de pasajeros del taxi {taxiNumero}:");
                esEnteroValido = validarEntero(Console.ReadLine(), 1, 4, out cant);

                if (esEnteroValido)
                {
                    transportes.Add(new Taxi(cant));
                    taxiNumero++;
                    Console.Clear();
                }


            } while (taxiNumero <= 5);



            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Ingresa la cantidad de pasajeros del Omnibus {omnibusNumero}:");
                esEnteroValido = validarEntero(Console.ReadLine(), 1, 100, out cant);  // Asumo que la cantidad maxima de pasajeros admitidos es 100

                if (esEnteroValido)
                {
                    transportes.Add(new Omnibus(cant));
                    omnibusNumero++;
                    Console.Clear();
                }


            } while (omnibusNumero <= 5);

          

            Console.Clear();
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            int contador = 1;
            foreach (var transporte in transportes)
            {
                if (contador == 6)
                {
                    contador++;
                    Console.WriteLine("\n");
                }

                if (transporte.CantPasajeros == 1)
                    Console.WriteLine($"{transporte.GetType().Name } {contador%6}: {transporte.CantPasajeros} pasajero");

                else
                    Console.WriteLine($"{transporte.GetType().Name} {contador%6}: {transporte.CantPasajeros} pasajeros");

                contador++;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n Presiona enter para finalizar");

            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("           _ _,---._ \r\n       ,-','       `-.___ \r\n      /-;'               `._ \r\n     /\\/          ._   _,'o \\ \r\n    ( /\\       _,--'\\,','\"`. ) \r\n     |\\      ,'o     \\'    //\\ \r\n     |      \\        /   ,--'\"\"`-. \r\n     :       \\_    _/ ,-'         `-._ \r\n      \\        `--'  /                ) \r\n       `.  \\`._    ,'     ________,',' \r\n         .--`     ,'  ,--` __\\___,;' \r\n          \\`.,-- ,' ,`_)--'  /`.,' \r\n           \\( ;  | | )      (`-/      _________________________\r\n             `--'| |)       |-/      /                         \\\r\n               | | |        | |     <  Buenas practicaaaasss!!  >\r\n               | | |,.,-.   | |_     \\_________________________/\r\n               | `./ /   )---`  ) \r\n              _|  /    ,',   ,-' \r\n             ,'|_(    /-<._,' |--, \r\n             |    `--'---.     \\/ \\ \r\n             |          / \\    /\\  \\ \r\n           ,-^---._     |  \\  /  \\  \\ \r\n        ,-'        \\----'   \\/    \\--`.   "); 
            Console.ReadLine();



            bool validarEntero(string input, int pasajerosMinimos, int pasajerosMaximos, out int resultado)
            {
                bool inputValido = int.TryParse(input, out resultado);

                String transporte;
                if (pasajerosMaximos >= 5)
                {
                    transporte = "Omnibus";
                }
                else
                    transporte = "taxi";

                Console.ForegroundColor = ConsoleColor.Red;
                if (inputValido)
                {
                    if (resultado < pasajerosMinimos || resultado > pasajerosMaximos)
                    {

                        Console.WriteLine($"Cantidad incorrecta, el {transporte} solo puede llevar entre {pasajerosMinimos} y {pasajerosMaximos} pasajeros");
                        inputValido = false;
                    }
                }
                else
                    Console.WriteLine("Por favor ingresar solo numeros");

                return inputValido;
            }
        }
    }
}