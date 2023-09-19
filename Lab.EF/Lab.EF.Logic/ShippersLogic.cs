using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Lab.EF.Logic.DTO;

namespace Lab.EF.Logic
{
    public class ShippersLogic : BaseLogic, IShippersLogic
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
            ValidateService.ValidateShipper(shipper);

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
            ValidateService.ValidateShipper(shipper);

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

                if (shipperToDelete != null)
                {
                    context.Shippers.Remove(shipperToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("No se encontró el shipper para eliminar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("No se puede eliminar este Shipper");
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
