using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeFoodNearMe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string[] list = { "1", "2", "3", "4", "5" };
            ViewBag.list = list;
            return View();
        }

        public ActionResult RegisterService()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }        
    }
}