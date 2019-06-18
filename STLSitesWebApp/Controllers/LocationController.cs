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
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LocationCreateViewModel location)
        {
            //context.Add(location);
            //context.SaveChanges();


            return View();
        }

    }
}