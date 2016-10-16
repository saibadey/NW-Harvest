using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NWHarvest.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var test = this.User;
            return View();
        }
    }
}