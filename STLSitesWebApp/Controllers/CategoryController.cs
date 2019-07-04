using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STLSitesWebApp.Data;
using STLSitesWebApp.Models;
using STLSitesWebApp.ViewModels.Category;

namespace STLSitesWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext context;
        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Category> categories = context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CategoryCreateViewModel viewModel = new CategoryCreateViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Persist(context);
            return RedirectToAction(controllerName: "Category", actionName: "Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            context.Remove(context.Categories.Find(Id));
            context.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}