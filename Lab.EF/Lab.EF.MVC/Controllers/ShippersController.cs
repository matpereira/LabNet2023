using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.Logic.DTO;
using Lab.EF.MVC.Models;

namespace Lab.EF.MVC.Controllers
{
    public class ShippersController : Controller
    {
        ShippersLogic shipperLogic = new ShippersLogic();

        // Mostrar la lista de Shippers
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
        public ActionResult Insert(ShippersView shipper)
        {
            string validationError = ValidateShipper(shipper);

            if (!string.IsNullOrEmpty(validationError))
            {
                ViewBag.ErrorMessage = validationError;
                return RedirectToAction("Index", "Error");
            }

            try
            {
                var shipperEntity = new ShippersDTO { CompanyName = shipper.CompanyName, Phone = shipper.Phone };
                shipperLogic.Add(shipperEntity);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Ocurrió un error al agregar el shipper: {ex.Message}";
                return RedirectToAction("Index", "Error");
            }
        }

        private string ValidateShipper(ShippersView shipper)
        {
            if (shipper.CompanyName.Length > 40)
            {
                return "El nombre de la compañía es demasiado largo.";
            }

            if (!EsNumeroTelefonoValido(shipper.Phone))
            {
                return "Número de teléfono no válido.";
            }

            return null; // No hay errores   
        }

        public static bool EsNumeroTelefonoValido(string numero)
        {
            string patron = @"^(?=\(?\+?\d{1,3}\)?)(?=.{1,24}$)\(?\+?\d{1,3}\)?[\s-]?\d{1,24}$";
            return Regex.IsMatch(numero, patron);
        }

        
        public ActionResult Delete(int id)
        {
            shipperLogic.Delete(id);
            return RedirectToAction("Index");
        }
        /*
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                shipperLogic.Delete(id);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "No se puede eliminar un shipper que esté asociado a un pedido." });
            }

            public ActionResult Update(int id)
        {
            ShippersDTO shipper = shipperLogic.Find(id);

            if (shipper == null)
            {
                return HttpNotFound();
            }

            ShippersView shipperView = new ShippersView { ShipperID = shipper.ShipperID, CompanyName = shipper.CompanyName, Phone = shipper.Phone };

            return View(shipperView);
        }*/

        [HttpPost]
        public JsonResult Update(ShippersView shipper)
        {
            if (shipper == null || shipper.ShipperID <= 0)
            {
                return Json(new { success = false, message = "ID de shipper no válido." });
            }

            string validationError = ValidateShipper(shipper);

            if (!string.IsNullOrEmpty(validationError))
            {
                return Json(new { success = false, message = validationError });
            }

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
