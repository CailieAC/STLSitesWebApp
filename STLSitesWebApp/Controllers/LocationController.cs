using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STLSitesWebApp.Data;
using STLSitesWebApp.Models;
using STLSitesWebApp.ViewModels;
using STLSitesWebApp.ViewModels.Location;

namespace STLSitesWebApp.Controllers
{
    public class LocationController : Controller
    {
       
        //We added a context constructor here, but ideally this should not be located in the controller
        private ApplicationDbContext context;
        public LocationController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<LocationListItemViewModel> locations = LocationListItemViewModel.GetLocations(context);
            return View(locations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LocationCreateViewModel viewModel = new LocationCreateViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(LocationCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            model.Persist(context);
            return RedirectToAction(controllerName: "Location", actionName: "Index");

        }

        [HttpGet]
        public IActionResult Details(int locationId)
        {
            LocationDetailsViewModel location = LocationDetailsViewModel.GetLocation(locationId, context);
            return View(location);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(new LocationEditViewModel(id, context));
            //return View(context.Locations.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, LocationEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                //location.ResetLocationList(context);
                return View(viewModel);
            }

            viewModel.Persist(id, context);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            context.Remove(context.Locations.Find(id));
            context.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}