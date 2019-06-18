using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace STLSitesWebApp.Controllers
{
    public class LocationRatingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}