using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Lab.EF.Logic
{
    public class ShippersLogic : BaseLogic
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
            var shipperToDelete = context.Shippers.Find(id);
            try
            {
                context.Shippers.Remove(shipperToDelete);
                context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine($"{id} no encontrado");
            }
            
        }

        public int Find(int id)
        {
         var shipper = context.Shippers.Find(id);
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
                return 0;
            }
        }
    }
}
