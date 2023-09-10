using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.Logic.DTO;
using Lab.EF.MVC.Models;

namespace Lab.EF.MVC.Controllers
{
    public class CustomersController : Controller
    {
        CustomersLogic customerLogic = new CustomersLogic();

        public ActionResult Index()
        {
            List<CustomersDTO> customers = customerLogic.GetAll();
            List<CustomersView> customersView = customers.Select(c => new CustomersView
            {
                CustomerID = c.CustomerID,
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                Address = c.Address,
                Region = c.Region,
            }).ToList();
            return View(customersView);
        }


        [HttpPost]
        public JsonResult Delete(string id)
        {
            try
            {
                // Tu lógica de eliminación aquí
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al eliminar el cliente: {ex.Message}" });
            }
        }
    }
}
