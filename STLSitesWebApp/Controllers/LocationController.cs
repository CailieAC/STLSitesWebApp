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
        //Add a context constructor here, but ideally should not be located in the controller
        //private ApplicationDbContext context;
        //public LocationController(ApplicationDbContext context)
        //{
        //    this.context = context;
        //}

        public IActionResult Index(LocationListItemViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LocationCreateViewModel model)
        {
            //context.Add(location);
            //context.SaveChanges();

            //TODO: Figure out how to save to context
            /* 
            if (!ModelState.IsValid)
                return View(model);

            model.Persist(context);
            return RedirectToAction(controllerName: "Movie", actionName: "Index");
            */

            return View();
        }

    }
}