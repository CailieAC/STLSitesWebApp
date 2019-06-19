using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STLSitesWebApp.Data;
using STLSitesWebApp.Models;
using STLSitesWebApp.ViewModels;

namespace STLSitesWebApp.Controllers
{
    public class LocationController : Controller
    {
       
        //TODO We added a context constructor here, but ideally this should not be located in the controller
        private ApplicationDbContext context;
        public LocationController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //public IActionResult Index(LocationListItemViewModel model)
        public IActionResult Index()
        {
            List<Location> locations = Location.GetLocations(context);
            return View(locations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            if (!ModelState.IsValid)
                return View(location);
            
            location.Persist(context);
            return RedirectToAction(controllerName: "Location", actionName: "Index");

        }

    }
}