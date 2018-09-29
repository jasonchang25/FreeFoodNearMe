using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreeFoodNearMe.Services;
using FreeFoodNearMe.Models;
using FreeFoodNearMe.Repositories;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;
using System.Diagnostics;
using System.Security.Claims;

namespace FreeFoodNearMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly SiteService siteService;

        public HomeController()
        {
            this.siteService = new SiteService();
        }

        /************************************ Home Page *******************************************************/

        public async Task<ActionResult> Index()
        {
            string[] list = { "1", "2", "3", "4", "5" };
            ViewBag.list = list;
            return View();
        }


        /************************************ Register Service *******************************************************/
        public ActionResult RegisterService()
        {
            var ServiceType = new List<SelectListItem>();
            ServiceType.Add(new SelectListItem { Text = "Permanent", Value = "Permanent" });
            ServiceType.Add(new SelectListItem { Text = "Event", Value = "Event" });
            ViewBag.ServiceType = ServiceType;

            return View();
        }

        [HttpPost]
        [ActionName("RegisterService")]
        public async Task<ActionResult> RegisterService([Bind(Include = "Id,Type,ServiceName,Website,CompanyName,Address,Suburb,PostCode,State,Lat,Lng,ContactNumber,ServiceDescription,ServiceType,DateStart,DateEnd,SundayStart,SundayEnd,MondayStart,MondayEnd,TuesdayStart,TuesdayEnd,WednesdayStart,WednesdayStart,ThursdayStart,ThursdayEnd,FridayStart,FridayEnd,SaturdayStart,SaturdayEnd")] Service ThisService)
        {
            if (ThisService == null)
            {
                return HttpNotFound();
            }
            ThisService.Type = "PendingService";
            await siteService.ServicesAddService(ThisService);
            return Redirect("~/");
        }

        /************************************ Login ***************************************************/ 
        public ActionResult Login()
        {
            return View();
        }

        /************************************ Pending Services *******************************************************/
        public async Task<ActionResult> PendingServices()
        {
            var PendingServices = await siteService.GetPendingServices();
            if (PendingServices == null)
            {
                return HttpNotFound();
            }
            return View(PendingServices);
        }

        /************************************ Pending Services Details *******************************************************/
        public async Task<ActionResult> PendingServiceDetail(string id)
        {
            var PendingService = await siteService.ServiceGetByID(id);
            if (PendingService == null)
            {
                return HttpNotFound();
            }
            var ServiceType = new List<SelectListItem>();
            ServiceType.Add(new SelectListItem { Text = "Permanent", Value = "Permanent" });
            ServiceType.Add(new SelectListItem { Text = "Event", Value = "Event" });
            ViewBag.ServiceType = ServiceType;

            return View(PendingService);
        }

        [HttpPost]
        [ActionName("ApproveService")]
        public async Task<ActionResult> ApproveService([Bind(Include = "Id,Type,ServiceName,Website,CompanyName,Address,Suburb,PostCode,State,Lat,Lng,ContactNumber,ServiceDescription,ServiceType,DateStart,DateEnd,SundayStart,SundayEnd,MondayStart,MondayEnd,TuesdayStart,TuesdayEnd,WednesdayStart,WednesdayStart,ThursdayStart,ThursdayEnd,FridayStart,FridayEnd,SaturdayStart,SaturdayEnd")] Service ThisService)
        {
            if (ThisService == null)
            {
                return HttpNotFound();
            }
            ThisService.Type = "Service";            
            await siteService.EditService(ThisService);
            return RedirectToAction("/PendingServices");
        }

        public async Task<ActionResult> RejectService(string id)
        {
            Service ThisService = await siteService.ServiceGetByID(id);
            if (ThisService == null)
            {
                return HttpNotFound();
            }
            await siteService.DeleteService(ThisService);
            return RedirectToAction("/PendingServices");
        }
    }
}