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
            var Services = await siteService.GetAllServices();
            if (Services == null)
            {
                return HttpNotFound();
            }

            List<string> ServiceNamesList = new List<string>();
            foreach (var service in Services)
            {
                ServiceNamesList.Add(service.ServiceName);
            }
            string[] ServiceNamesArray = ServiceNamesList.ToArray();

            ViewBag.ServiceNames = ServiceNamesArray;
            return View(Services);
        }


        /************************************ Register Service *******************************************************/
        public ActionResult RegisterService()
        {
            var ServiceType = new List<SelectListItem>();
            ServiceType.Add(new SelectListItem { Text = "Permanent Service", Value = "Permanent Service" });
            ServiceType.Add(new SelectListItem { Text = "Event", Value = "Event" });
            ViewBag.ServiceType = ServiceType;

            return View();
        }

        [HttpPost]
        [ActionName("RegisterService")]
        public async Task<ActionResult> RegisterService([Bind(Include = "Id,Type,ServiceName,Website,CompanyName,Address,Suburb,PostCode,State,Lat,Lng,ContactNumber,ServiceDescription,ServiceType,DateStart,DateEnd,SundayStart,SundayEnd,MondayStart,MondayEnd,TuesdayStart,TuesdayEnd,WednesdayStart,WednesdayEnd,ThursdayStart,ThursdayEnd,FridayStart,FridayEnd,SaturdayStart,SaturdayEnd")] Service ThisService)
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

        [HttpPost]
        [ActionName("SignIn")]
        public ActionResult SignIn(string username, string password)
        {
            if(username == "Admin" && password == "Password123")
            {
                Session["User"] = "Admin";
                return RedirectToAction("/PendingServices");
            }
            else
            {
                return Redirect("/Home/Login?credential=invalid");
            }           
        }

        /************************************ Pending Services *******************************************************/
        public async Task<ActionResult> PendingServices()
        {
            if(Session["User"] != "Admin")
            {
                return Redirect("~/");
            }
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
            if (Session["User"] != "Admin")
            {
                return Redirect("~/");
            }
            var PendingService = await siteService.ServiceGetByID(id);
            if (PendingService == null)
            {
                return HttpNotFound();
            }
            var ServiceType = new List<SelectListItem>();
            ServiceType.Add(new SelectListItem { Text = "Permanent Service", Value = "Permanent Service" });
            ServiceType.Add(new SelectListItem { Text = "Event", Value = "Event" });
            ViewBag.ServiceType = ServiceType;

            return View(PendingService);
        }

        [HttpPost]
        [ActionName("ApproveService")]
        public async Task<ActionResult> ApproveService([Bind(Include = "Id,Type,ServiceName,Website,CompanyName,Address,Suburb,PostCode,State,Lat,Lng,ContactNumber,ServiceDescription,ServiceType,DateStart,DateEnd,SundayStart,SundayEnd,MondayStart,MondayEnd,TuesdayStart,TuesdayEnd,WednesdayStart,WednesdayEnd,ThursdayStart,ThursdayEnd,FridayStart,FridayEnd,SaturdayStart,SaturdayEnd")] Service ThisService)
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

        /************************************ Services Detail page *******************************************************/
        public async Task<ActionResult> ServiceDetails(string id)
        {
            var Service = await siteService.ServiceGetByID(id);
            if (Service == null)
            {
                return HttpNotFound();
            }
            ViewBag.SelectedService = Service;           
         
            var Stories = await siteService.GetAllStoriesForService(id);
            if (Stories == null)
            {
                return HttpNotFound();
            }      
            return View(Stories);
        }

        [HttpPost]
        [ActionName("ShareStory")]
        public async Task<ActionResult> ShareStory(string DisplayName, string StoryContent, string Service)
        {
            var Story = new Stories();
            Story.displayName = DisplayName;
            Story.ServiceId = Service;
            Story.StoryContent = StoryContent;
            Story.PostDate = DateTime.Now.ToString();

            await siteService.StoriesAddStory(Story);
            return Redirect("ServiceDetails/"+Service);
        }
    }
}