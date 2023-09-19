using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lab.EF.Logic;
using Lab.EF.Logic.DTO;
using Lab.EF.MVC.Models;



namespace Lab.EF.MVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersLogic customerLogic;

        public CustomersController(ICustomersLogic customersLogic) =>
            this.customerLogic = customersLogic;

        public ActionResult Index()
        {
            List<CustomersDTO> customers = customerLogic.GetAll();
            List<CustomersView> customersView = customers.Select(c => new CustomersView
            {
                CustomerID = c.CustomerID,
                CompanyName = c.CompanyName,
                Address = c.Address,
                Phone = c.Phone
            }).ToList();
            return View(customersView);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Insert(CustomersView customer)
        {
            try
            {
                var customerEntity = new CustomersDTO { CustomerID = customer.CustomerID, CompanyName = customer.CompanyName, Phone = customer.Phone };
                customerLogic.Add(customerEntity);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Ocurrió un error al agregar el Cliente: {ex.Message}" });
            }
        }


        public ActionResult Delete(string id)
        {
            try
            {
                customerLogic.Delete(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }



        public JsonResult Update(CustomersView customer)
        {

            try
            {
                var customerEntity = new CustomersDTO { CustomerID = customer.CustomerID, CompanyName = customer.CompanyName, Phone = customer.Phone };
                customerLogic.Update(customerEntity);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al actualizar el shipper: {ex.Message}" });
            }
        }


    }
}
