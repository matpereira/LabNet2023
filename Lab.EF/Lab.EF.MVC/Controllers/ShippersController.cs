using System.Collections.Generic;
using System.Web.Mvc;
using Lab.EF.Logic;
using Lab.EF.Logic.DTO;

namespace Lab.EF.MVC.Controllers
{
    public class ShippersController : Controller
    {
        // Mostrar la lista de Shippers
        public ActionResult Index()
        {
            ShippersLogic shipperLogic = new ShippersLogic();

            var shippers = shipperLogic.GetAll();
            return View(shippers);
        }


    }
}