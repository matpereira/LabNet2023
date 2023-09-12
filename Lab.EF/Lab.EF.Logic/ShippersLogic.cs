using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Lab.EF.Logic.DTO;

namespace Lab.EF.Logic
{
    public class ShippersLogic : BaseLogic, ILogic<Shippers, ShippersDTO>
    {

        public List<ShippersDTO> GetAll()
        {
            return context.Shippers
                .Select(shipper => new ShippersDTO
                {
                    ShipperID = shipper.ShipperID,
                    CompanyName = shipper.CompanyName,
                    Phone = shipper.Phone
                })
                .ToList();
        }

        public void Add(ShippersDTO shipper)
        {
            var shipperToAdd = new Shippers
            {
                ShipperID = shipper.ShipperID,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            };
            context.Shippers.Add(shipperToAdd);
            context.SaveChanges();
        }

        public void Update(ShippersDTO shipper)
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
            Console.WriteLine("No se puede eliminar el shipper");
        }
    }


        public ShippersDTO Find(int id)
        {
            var shipper = context.Shippers.Find(id);

            if (shipper != null)
            {
                return new ShippersDTO
                {
                    ShipperID = shipper.ShipperID,
                    CompanyName = shipper.CompanyName,
                    Phone = shipper.Phone
                };
            }
            else
            {
                return null;
            }
        }

    }
}
