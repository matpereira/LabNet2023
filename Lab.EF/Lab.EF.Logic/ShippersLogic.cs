using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Lab.EF.Logic
{
public class ShippersLogic : BaseLogic, ILogic<Shippers>
    {

    public  List<Shippers> GetAll()
    {
        return context.Shippers.ToList();
    }

    public void Add(Shippers shipper)
    {
        context.Shippers.Add(shipper);
        context.SaveChanges();
    }
            
    public void Update(Shippers shipper)
    {
        var shipperToUpdate = context.Shippers.Find(shipper.ShipperID);
        shipperToUpdate.CompanyName = shipper.CompanyName;
        shipperToUpdate.Phone = shipper?.Phone;
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        try
        {
            var shipperToDelete = context.Shippers.FirstOrDefault(x => x.ShipperID == id);  
            context.Shippers.Remove(shipperToDelete);
            context.SaveChanges();
        }
        catch (Exception)
        {
            Console.WriteLine("No se puede eliminar un shipper que este asociado a un pedido");
        }

    }

    public int Find(int id)
    {
            
        var shipper = context.Shippers.Find(id);

        shipper = context.Shippers.FirstOrDefault(x => x.ShipperID == id);
          
        if (shipper != null)
        {
            Console.Clear();
            Console.WriteLine("Shipper encontrado");
            Console.WriteLine("ID\t|\tNombre de la compania\t|\tTelefono");
            Console.WriteLine($"{shipper.ShipperID}\t|\t{shipper.CompanyName}\t|\t{shipper.Phone}");
            return shipper.ShipperID;
        }
        else
        {
            Console.WriteLine($"No se encontro el shipper para el id: {id}");
            return 0;
        }
    }
}
}
