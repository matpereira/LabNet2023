using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Text.RegularExpressions;

namespace Lab.EF.UI
{
public class UIFunctions
{
        
    public void ObtenerShippers(ShippersLogic shipperLogic)
    {
        Console.WriteLine("ID\t|\tNombre de la compania\t|\tTelefono");

        var shippers = shipperLogic.GetAll();
        foreach (var shipper in shippers)
        {
            if(shipper.CompanyName.Length < 16)
                Console.WriteLine($"{shipper.ShipperID}\t|\t{shipper.CompanyName}\t\t\t|\t{shipper.Phone}");
            else
            Console.WriteLine($"{shipper.ShipperID}\t|\t{shipper.CompanyName}\t|\t{shipper.Phone}");
        }
    }

    public void ObtenerCustomers(CustomersLogic customerLogic)
    {
        var customers = customerLogic.GetAll();
        foreach (var customer in customers)
        {

        Console.WriteLine($"{customer.CustomerID}\t| {customer.CompanyName}\t| {customer.ContactName}\t| {customer.ContactTitle}\t| {customer.City}\t| {customer.Phone}");
        }
    }

    public void MostrarMenu()
    {
        Console.WriteLine("1. Agregar Shipper");
        Console.WriteLine("2. Actualizar Shipper");
        Console.WriteLine("3. Eliminar Shipper");
        Console.WriteLine("4. Mostrar Shippers");
        Console.WriteLine("5. Mostrar Customers");
        Console.WriteLine("0. Salir");
    }

    public bool EsNumeroTelefonoValido(string numero)
    {
        //Aclaracion sobre esta Regex:

        //Permite un símbolo "+" opcional antes de dos dígitos.
        //Permite paréntesis opcionales alrededor del código de país.
        //Acepta guiones intermedios opcionales.
        //Acepta formatos como "(+54)911-2233-5544" o "+5491122335544".
        //Verifica que la longitud total sea de hasta 24 caracteres.
        string patron = @"^(?=\(?\+?\d{1,3}\)?)(?=.{1,24}$)\(?\+?\d{1,3}\)?[\s-]?\d{1,24}$";

        bool esValido = Regex.IsMatch(numero, patron);

        if (esValido == false)
        {
            Console.WriteLine("Número de teléfono no válido.");
                
        }
        return esValido;
    }



    public void NuevoShipper(ShippersLogic shipperLogic)
    {
        UIFunctions uiFunction = new UIFunctions();


        Console.WriteLine("Ingrese el nombre de la compañia");
        var nombre = Console.ReadLine();
        while (nombre.Length > 40)
        {
            Console.Clear();
            Console.WriteLine("El nombre de la compania no puede superar los 40 caracteres");
            Console.WriteLine("por favor ingrese nuevamente el nombre de la compania");
            nombre = Console.ReadLine();
        }
        Console.WriteLine("Ingrese numero de telefono (Max 24 digitos)  ");
        var numeroTelefono = Console.ReadLine();

        if (uiFunction.EsNumeroTelefonoValido(numeroTelefono))
        {
            shipperLogic.Add(new Shippers
            {
                CompanyName = nombre,
                Phone = numeroTelefono
            });
        }

    }



    public void ModificarShipper(ShippersLogic shipperLogic)
    {
        UIFunctions uiFunction = new UIFunctions();
        Console.WriteLine("Ingrese el id a modificar");
        int id;
        string nombreCompania;

        if (int.TryParse(Console.ReadLine(), out id))
        {
            if (shipperLogic.Find(id) != 0)
            {
                Console.WriteLine("Modificar el nombre de la compañia? (S/N)");
                var confirmar = Console.ReadLine();
                if (confirmar == "S" || confirmar == "s")
                {
                    Console.WriteLine("Ingrese el nombre de la compañia");
                    nombreCompania = Console.ReadLine();
                    while (nombreCompania.Length > 40)
                    {
                        Console.Clear();
                        Console.WriteLine("El nombre de la compania no puede superar los 40 caracteres");
                        Console.WriteLine("por favor ingrese nuevamente el nombre de la compania");
                        nombreCompania = Console.ReadLine();
                    }
                }
                else
                {
                    //no lo veo eficiente ya que tengo que volver a leer la base de datos
                    //para obtener el nombre de la compania si paso por aqui

                    nombreCompania = shipperLogic.GetAll().Find(x => x.ShipperID == id).CompanyName;
                }


                Console.WriteLine("Modificar el numero de telefono?");
                confirmar = Console.ReadLine();
                if (confirmar == "S" || confirmar == "s")
                {
                    Console.WriteLine("Ingrese numero de telefono (Max 24 digitos)");
                    var numeroTelefono = Console.ReadLine();
                    if (uiFunction.EsNumeroTelefonoValido(numeroTelefono))
                    {
                        shipperLogic.Update(new Shippers
                        {
                            ShipperID = id,
                            CompanyName = nombreCompania,
                            Phone = numeroTelefono
                        });
                    }
                }
                else
                {
                    //no lo veo eficiente ya que tengo que volver a leer la base de datos
                    //para obtener el telefono de la compania si paso por aqui
                    shipperLogic.Update(new Shippers
                    {
                        ShipperID = id,
                        CompanyName = nombreCompania,
                        Phone = shipperLogic.GetAll().Find(x => x.ShipperID == id).Phone
                    });
                }

            }
            else
            {
                Console.WriteLine("El id ingresado no existe");
            }
        }
        else
        {
            Console.WriteLine("solo se aceptan numeros para el ID");
        }
    }


    public  void BorrarShipper(ShippersLogic shipperLogic)
    {
        Console.Clear();
        Console.WriteLine("Selecciona el id a eliminar");
        int id;
        if (int.TryParse(Console.ReadLine(), out id))
        {
            if (shipperLogic.Find(id) != 0)
            {
                Console.WriteLine("Esta seguro que desea eliminar el registro? ");
                Console.WriteLine(" Escriba S para confirmar u otra letra para cancelar");
                var confirmacion = Console.ReadLine();
                if (confirmacion == "S" || confirmacion == "s")
                {
                    shipperLogic.Delete(id);
                }
            }
        }
         else
        {
         Console.WriteLine("solo se aceptan numeros para el ID");
        }
    }

}
}   
