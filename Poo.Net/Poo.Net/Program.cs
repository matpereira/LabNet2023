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
            List<TransportePublico> transportes = new List<TransportePublico>();

            CapturarTaxis(transportes);
            CapturarOmnibuses(transportes);
            MostrarTransportes(transportes);

        }

        private static void CapturarTaxis(List<TransportePublico> transportes)
        {
            int taxiNumero = 1;
            while (taxiNumero <= 5)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Ingresa la cantidad de pasajeros del taxi {taxiNumero}:");
                if (ValidarEntero(Console.ReadLine(), 1, 4, out int cant))
                {
                    transportes.Add(new Taxi(cant));
                    taxiNumero++;
                    Console.Clear();
                }
            }
        }

        private static void CapturarOmnibuses(List<TransportePublico> transportes)
        {
         
            int omnibusNumero = 1;
            while (omnibusNumero <= 5)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Ingresa la cantidad de pasajeros del Omnibus {omnibusNumero}:");
                if (ValidarEntero(Console.ReadLine(), 1, 100, out int cant))
                {
                    transportes.Add(new Omnibus(cant));
                    omnibusNumero++;
                    Console.Clear();
                }
            }
        }

        private static void MostrarTransportes(List<TransportePublico> transportes)
        {
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
                    Console.WriteLine($"{transporte.GetType().Name} {contador % 6}: {transporte.CantPasajeros} pasajero");

                else
                    Console.WriteLine($"{transporte.GetType().Name} {contador % 6}: {transporte.CantPasajeros} pasajeros");

                contador++;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\nPresiona la tecla Enter para finalizar....");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("           _ _,---._ \r\n       ,-','       `-.___ \r\n      /-;'               `._ \r\n     /\\/          ._   _,'o \\ \r\n    ( /\\       _,--'\\,','\"`. ) \r\n     |\\      ,'o     \\'    //\\ \r\n     |      \\        /   ,--'\"\"`-. \r\n     :       \\_    _/ ,-'         `-._ \r\n      \\        `--'  /                ) \r\n       `.  \\`._    ,'     ________,',' \r\n         .--`     ,'  ,--` __\\___,;' \r\n          \\`.,-- ,' ,`_)--'  /`.,' \r\n           \\( ;  | | )      (`-/      _________________________\r\n             `--'| |)       |-/      /                         \\\r\n               | | |        | |     <  Buenas practicaaaasss!!  >\r\n               | | |,.,-.   | |_     \\_________________________/\r\n               | `./ /   )---`  ) \r\n              _|  /    ,',   ,-' \r\n             ,'|_(    /-<._,' |--, \r\n             |    `--'---.     \\/ \\ \r\n             |          / \\    /\\  \\ \r\n           ,-^---._     |  \\  /  \\  \\ \r\n        ,-'        \\----'   \\/    \\--`.   ");
            Console.ReadLine();
        }

       private static bool ValidarEntero(string input, int pasajerosMinimos, int pasajerosMaximos, out int resultado)
        {
            bool inputValido = int.TryParse(input, out resultado);

            string transporte = pasajerosMaximos >= 5 ? "Omnibus" : "Taxi";

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