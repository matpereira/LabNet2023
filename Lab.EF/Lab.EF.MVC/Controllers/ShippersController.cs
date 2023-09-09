using System.Web.Mvc;
using Lab.EF.Logic;
using Lab.EF.Logic.DTO;
using System.Collections.Generic;
using System.Drawing;
using Lab.EF.MVC.Models;
using System.Linq;
using System;
using System.Text.RegularExpressions;

namespace Lab.EF.MVC.Controllers
{
    public class ShippersController : Controller
    {
        ShippersLogic shipperLogic = new ShippersLogic();

        // Mostrar la lista de Shippers
        public ActionResult Index()
        {
            ShippersLogic shipperLogic = new ShippersLogic();
            List<ShippersDTO> shippers = shipperLogic.GetAll();
            List<ShippersView> shippersView = shippers.Select(s => new ShippersView { CompanyName = s.CompanyName, Phone = s.Phone }).ToList();
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
    }

    public ActionResult Delete(int id)
    {
        try
        {
            shipperLogic.Delete(id);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = $"Ocurrió un error al eliminar el shipper: {ex.Message}";
            return RedirectToAction("Index", "Error");
        }
    }

}