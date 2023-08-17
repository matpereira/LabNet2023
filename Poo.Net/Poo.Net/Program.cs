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


            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Ingresa la cantidad de pasajeros del taxi {taxiNumero}:");
                esEnteroValido = validarEntero(Console.ReadLine(), 1, 4, out cant);

                if (esEnteroValido)
                {
                    taxis.Add(new Taxi (cant));
                    taxiNumero++;
                    Console.Clear();
                }
                    

            } while ( taxiNumero <=  5);



            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Ingresa la cantidad de pasajeros del Omnibus {omnibusNumero}:");
                esEnteroValido = validarEntero(Console.ReadLine(), 1, 100, out cant);  // Asumo que la cantidad maxima de pasajeros admitidos es 100

                if (esEnteroValido)
                {
                    omnibuses.Add(new Omnibus(cant));
                    omnibusNumero++;
                    Console.Clear();
                }


            } while (omnibusNumero <= 5);


            Console.Clear();
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            int contador=1;
            foreach (var taxi in taxis )
	        {
                if(taxi.CantPasajeros == 1)
                    Console.WriteLine($"Taxi {contador}: {taxi.CantPasajeros} pasajero");

                else
                    Console.WriteLine($"Taxi {contador}: {taxi.CantPasajeros} pasajeros");

                contador++;
            }

            Console.WriteLine("\n");

            contador = 1;
            foreach (var omnibus in omnibuses)
            {
               
                if (omnibus.CantPasajeros == 1)
                    Console.WriteLine($"Omnibus {contador}: {omnibus.CantPasajeros} pasajero");
                else
                    Console.WriteLine($"Omnibus {contador}: {omnibus.CantPasajeros} pasajeros");
                contador++;
            }
            Console.ReadLine();
          


            bool validarEntero (string input, int pasajerosMinimos, int pasajerosMaximos, out int resultado )
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
