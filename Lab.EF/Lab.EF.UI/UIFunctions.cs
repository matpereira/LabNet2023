using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab.EF.UI
{
    public class UIFunctions
    {

        public void MostrarMenu()
        {
            Console.WriteLine("1. Agregar Shipper");
            Console.WriteLine("2. Actualizar Shipper");
            Console.WriteLine("3. Eliminar Shipper");
            Console.WriteLine("4. Mostrar Shippers");
            Console.WriteLine("5. Agregar Customer");
            Console.WriteLine("6. Actualizar Customer");
            Console.WriteLine("7. Eliminar Customer");
            Console.WriteLine("8. Mostrar Customers");
            Console.WriteLine("0. Salir");
        }

        public static bool EsNumeroTelefonoValido(string numero)
        {
            string patron = @"^(?=\(?\+?\d{1,3}\)?)(?=.{1,24}$)\(?\+?\d{1,3}\)?[\s-]?\d{1,24}$";
            return Regex.IsMatch(numero, patron);
        }

        public static string LeerCadenaConLongitudMaxima(string mensaje, int longitudMaxima)
        {
            string entrada;
            do
            {
                Console.WriteLine(mensaje);
                entrada = Console.ReadLine();

                if (entrada.Length > longitudMaxima)
                {
                    Console.WriteLine($"La entrada no puede superar los {longitudMaxima} caracteres.");
                }
            } while (entrada.Length > longitudMaxima);

            return entrada;
        }

    }
}
