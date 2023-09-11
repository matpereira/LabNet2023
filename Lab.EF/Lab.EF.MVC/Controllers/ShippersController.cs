using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lab.EF.Logic;
using Lab.EF.Logic.DTO;
using Lab.EF.MVC.Models;

namespace Lab.EF.MVC.Controllers
{
    public class ShippersController : Controller
    {
        ShippersLogic shipperLogic = new ShippersLogic();

        public ActionResult Index()
        {
            List<ShippersDTO> shippers = shipperLogic.GetAll();
            List<ShippersView> shippersView = shippers.Select(s => new ShippersView { ShipperID = s.ShipperID, CompanyName = s.CompanyName, Phone = s.Phone }).ToList();
            return View(shippersView);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Insert(ShippersView shipper)
        {
            try
            {
                var shipperEntity = new ShippersDTO { CompanyName = shipper.CompanyName, Phone = shipper.Phone };
                shipperLogic.Add(shipperEntity);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Ocurrió un error al agregar el shipper: {ex.Message}" });
            }
        }




        public ActionResult Delete(int id)
        {
            shipperLogic.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Update(ShippersView shipper)
        {

            try
            {
                var shipperEntity = new ShippersDTO { ShipperID = shipper.ShipperID, CompanyName = shipper.CompanyName, Phone = shipper.Phone };
                shipperLogic.Update(shipperEntity);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al actualizar el shipper: {ex.Message}" });
            }
        }
    }
}
