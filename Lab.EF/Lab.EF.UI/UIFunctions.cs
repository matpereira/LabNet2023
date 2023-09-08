using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.Logic.DTO;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab.EF.UI
{
public class UIFunctions
{
        public void ObtenerShippers(ShippersLogic shipperLogic)
        {
            Console.WriteLine("ID\t|\tNombre de la compania\t|\tTelefono");

            var shippers = shipperLogic.GetAll().Select(shipper => new ShippersDTO
            {
                ShipperID = shipper.ShipperID,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            }).ToList();

            foreach (var shipper in shippers)
            {
                if (shipper.CompanyName.Length < 16)
                    Console.WriteLine($"{shipper.ShipperID}\t|\t{shipper.CompanyName}\t\t\t|\t{shipper.Phone}");
                else
                    Console.WriteLine($"{shipper.ShipperID}\t|\t{shipper.CompanyName}\t|\t{shipper.Phone}");
            }
        }




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
            var nombre = IngresarCompania();

            Console.WriteLine("Ingrese numero de telefono (Max 24 digitos)  ");
            var numeroTelefono = Console.ReadLine();

            if (uiFunction.EsNumeroTelefonoValido(numeroTelefono))
            {
                shipperLogic.Add(new ShippersDTO
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
                var shipperDTO = shipperLogic.Find(id);

                if (shipperDTO != null)
                {
                    Console.WriteLine("Modificar el nombre de la compañia? (S/N)");
                    var confirmar = Console.ReadLine();
                    if (confirmar == "S" || confirmar == "s")
                    {
                        nombreCompania = IngresarCompania();
                    }
                    else
                    {
                        nombreCompania = shipperDTO.CompanyName;
                    }

                    Console.WriteLine("Modificar el numero de telefono? (S/N)");
                    confirmar = Console.ReadLine();
                    if (confirmar == "S" || confirmar == "s")
                    {
                        Console.WriteLine("Ingrese numero de telefono (Max 24 digitos)");
                        var numeroTelefono = Console.ReadLine();
                        if (uiFunction.EsNumeroTelefonoValido(numeroTelefono))
                        {
                            shipperLogic.Update(new ShippersDTO
                            {
                                ShipperID = id,
                                CompanyName = nombreCompania,
                                Phone = numeroTelefono
                            });
                        }
                    }
                    else
                    {
                        shipperLogic.Update(new ShippersDTO
                        {
                            ShipperID = id,
                            CompanyName = nombreCompania,
                            Phone = shipperDTO.Phone
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


        private string IngresarCompania()
        {

            Console.WriteLine("Ingrese el nombre de la compañia");
            var nombre = Console.ReadLine();
            while (nombre.Length > 40)
            {
                Console.Clear();
                Console.WriteLine("El nombre de la compania no puede superar los 40 caracteres");
                Console.WriteLine("por favor ingrese nuevamente el nombre de la compania");
                nombre = Console.ReadLine();
            }
            return nombre;
        }


        public void BorrarShipper(ShippersLogic shipperLogic)
        {
            Console.Clear();
            Console.WriteLine("Selecciona el id a eliminar");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                var shipperDTO = shipperLogic.Find(id);

                if (shipperDTO != null)
                {
                    Console.WriteLine("¿Está seguro que desea eliminar el registro? ");
                    Console.WriteLine("Escriba S para confirmar u otra letra para cancelar");
                    var confirmacion = Console.ReadLine();
                    if (confirmacion == "S" || confirmacion == "s")
                    {
                        shipperLogic.Delete(id);
                    }
                }
                else
                {
                    Console.WriteLine("El ID ingresado no existe");
                }
            }
            else
            {
                Console.WriteLine("Solo se aceptan números para el ID");
            }
        }

        //////////Customers
        public void NuevoCustomer(CustomersLogic customerLogic)
        {
            UIFunctions uiFunction = new UIFunctions();
            Console.WriteLine("Ingrese el nombre de la compañía");
            var nombreCompania = Console.ReadLine();

            while(nombreCompania.Length>49 || nombreCompania.Length<0 )
            {
                Console.WriteLine("El nombre de la compañía no puede superar los 40 caracteres");
                Console.WriteLine("por favor ingrese nuevamente el nombre de la compañía");
                nombreCompania = Console.ReadLine();
            }

            Console.WriteLine("Ingrese el nombre de contacto");
            var nombreContacto = Console.ReadLine();

            while (nombreContacto.Length > 30)
            {
                Console.WriteLine("El nombre de contacto no puede superar los 40 caracteres");
                Console.WriteLine("por favor ingrese nuevamente el nombre de contacto");
                nombreContacto = Console.ReadLine();
            }

            Console.WriteLine("Ingrese el título de contacto");
            var tituloContacto = Console.ReadLine();

            while (tituloContacto.Length > 30)
            {
                Console.WriteLine("El título de contacto no puede superar los 40 caracteres");
                Console.WriteLine("por favor ingrese nuevamente el título de contacto");
                tituloContacto = Console.ReadLine();
            }

            Console.WriteLine("Ingrese la dirección");
            var direccion = Console.ReadLine();

            while (direccion.Length > 60)
            {
                Console.WriteLine("La dirección no puede superar los 40 caracteres");
                Console.WriteLine("por favor ingrese nuevamente la dirección");
                direccion = Console.ReadLine();
            }

            Console.WriteLine("Ingrese la ciudad");
            var ciudad = Console.ReadLine();

            while (ciudad.Length > 15)
            {
                Console.WriteLine("La ciudad no puede superar los 40 caracteres");
                Console.WriteLine("por favor ingrese nuevamente la ciudad");
                ciudad = Console.ReadLine();
            }
            Console.WriteLine("Ingrese la región");
            var region = Console.ReadLine();
            while (region.Length > 15)
            {
                Console.WriteLine("La región no puede superar los 40 caracteres");
                Console.WriteLine("por favor ingrese nuevamente la región");
                region = Console.ReadLine();
            }

            Console.WriteLine("Ingrese el código postal");
            var codigoPostal = Console.ReadLine();
            while (codigoPostal.Length > 10)
            {
                Console.WriteLine("El código postal no puede superar los 40 caracteres");
                Console.WriteLine("por favor ingrese nuevamente el código postal");
                codigoPostal = Console.ReadLine();
            }

            Console.WriteLine("Ingrese el país");
            var pais = Console.ReadLine();
            while (pais.Length > 15)
            {
                Console.WriteLine("El país no puede superar los 40 caracteres");
                Console.WriteLine("por favor ingrese nuevamente el país");
                pais = Console.ReadLine();
            }

            Console.WriteLine("Ingrese el número de teléfono (Max 24 dígitos)");
            var numeroTelefono = Console.ReadLine();

 
          
            Console.WriteLine("Ingrese el número de fax (Max 24 dígitos)");
            var numeroFax = Console.ReadLine();

       
                customerLogic.Add(new CustomersDTO
                {
                    CompanyName = nombreCompania,
                    ContactName = nombreContacto,
                    ContactTitle = tituloContacto,
                    Address = direccion,
                    City = ciudad,
                    Region = region,
                    PostalCode = codigoPostal,
                    Country = pais,
                    Phone = numeroTelefono,
                    Fax = numeroFax
                });
            
        }


        public void ObtenerCustomers(CustomersLogic customerLogic)
        {
            var customers = customerLogic.GetAll();
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.CustomerID}\t| {customer.CompanyName}\t| {customer.ContactName}\t| {customer.ContactTitle}\t| {customer.City}\t| {customer.Phone}");
            }
        }

        public void ModificarCustomer(CustomersLogic customerLogic)
        {
            UIFunctions uiFunction = new UIFunctions();
            Console.WriteLine("Ingrese el ID del cliente a modificar:");
            string id = Console.ReadLine();
            if (id.Length==5)
            {
                var customerDTO = customerLogic.Find(id);

                if (customerDTO != null)
                {
                    Console.WriteLine("Modificar el número de teléfono? (S/N)");
                    var confirmarTelefono = Console.ReadLine();
                    string nuevoTelefono = customerDTO.Phone;

                    if (confirmarTelefono == "S" || confirmarTelefono == "s")
                    {
                        Console.WriteLine("Ingrese el nuevo número de teléfono (Max 24 dígitos):");
                        nuevoTelefono = Console.ReadLine();
                        if (!uiFunction.EsNumeroTelefonoValido(nuevoTelefono))
                        {
                            Console.WriteLine("Número de teléfono no válido.");
                            return;
                        }
                    }

                    Console.WriteLine("Modificar la dirección? (S/N)");
                    var confirmarDireccion = Console.ReadLine();
                    string nuevaDireccion = customerDTO.Address;

                    if (confirmarDireccion == "S" || confirmarDireccion == "s")
                    {
                        Console.WriteLine("Ingrese la nueva dirección:");
                        nuevaDireccion = Console.ReadLine();
                        while (nuevaDireccion.Length > 60)
                        {
                            Console.WriteLine("La dirección no puede superar los 60 caracteres");
                            Console.WriteLine("por favor ingrese nuevamente la dirección");
                            nuevaDireccion = Console.ReadLine();
                        }
                        
                    }


                    // Actualizar solo los campos permitidos
                    customerLogic.Update(new CustomersDTO
                    {
                        CustomerID = customerDTO.CustomerID,
                        CompanyName = customerDTO.CompanyName,
                        ContactName = customerDTO.ContactName,
                        ContactTitle = customerDTO.ContactTitle,
                        City = customerDTO.City,
                        Country = customerDTO.Country,
                        PostalCode = customerDTO.PostalCode,
                        Region = customerDTO.Region,
                        Phone = nuevoTelefono,
                        Address = nuevaDireccion,
                        Fax = customerDTO.Fax
                    }); ;

                    Console.WriteLine("Cliente actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("El ID ingresado no existe.");
                }
            }
            else
            {
                Console.WriteLine("Solo se aceptan ID de longitud = 5");
            }
        }
        public void BorrarCustomer(CustomersLogic customerLogic)
        {
            Console.Clear();
            Console.WriteLine("Selecciona el ID del cliente a eliminar:");
            string id=Console.ReadLine();

            if (id.Length == 5)
            {
                var customerDTO = customerLogic.Find(id);

                if (customerDTO != null)
                {
                    Console.WriteLine("¿Está seguro que desea eliminar el registro? ");
                    Console.WriteLine("Escriba S para confirmar u otra letra para cancelar");
                    var confirmacion = Console.ReadLine();
                    if (confirmacion == "S" || confirmacion == "s")
                    {
                        customerLogic.Delete(id);
                        Console.WriteLine("Cliente eliminado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Eliminación cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("El ID ingresado no existe.");
                }
            }
            else
            {
                Console.WriteLine("Solo se aceptan ID de longitud = 5");
            }
        }



    }
}   
