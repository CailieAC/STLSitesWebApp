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

        public IActionResult Index()
        {
            return View(context.LocationListItemViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //LocationCreateViewModel viewModel = new LocationCreateViewModel(context);
            //return View(viewModel);
            return View(context.LocationCreateViewModel);
        }

        [HttpPost]
        public IActionResult Create(LocationCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            model.Persist(context);
            return RedirectToAction(controllerName: "Location", actionName: "Index");

        }

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    return View(context.Locations.Find(id));
        //}

        //[HttpPost]
        //public IActionResult Edit(int id, Location location)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        //location.ResetLocationList(context);
        //        return View(location);
        //    }

        //    location.Persist(id, context);
        //    return RedirectToAction(actionName: nameof(Index));
        //}

        [HttpGet]
        public IActionResult Delete(int id)
        {
            context.Remove(context.Locations.Find(id));
            context.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}