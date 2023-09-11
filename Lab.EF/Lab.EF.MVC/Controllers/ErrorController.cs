
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("Error");
        }
    }
}