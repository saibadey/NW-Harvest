using System.Web.Mvc;
using NWHarvest.Web.Models;

namespace NWHarvest.Web.Controllers
{
    

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var registeredUserService = new RegisteredUserService();
            var user = registeredUserService.GetRegisteredUser(this.User);
            ViewBag.userRole = user.Role;
            return View();
        }
    }
}