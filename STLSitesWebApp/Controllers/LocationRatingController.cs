using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STLSitesWebApp.Data;
using STLSitesWebApp.ViewModels;

namespace STLSitesWebApp.Controllers
{
    public class LocationRatingController : Controller
    {
        private ApplicationDbContext context;
        public LocationRatingController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /*
        public IActionResult Index()
        {
            return View();
        }
        */

        [HttpGet]
        public IActionResult Create(int locationId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int locationId, LocationRatingCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            viewModel.Persist(context);
            return RedirectToAction(controllerName: "Location", actionName: "Index");
        }

    }
}