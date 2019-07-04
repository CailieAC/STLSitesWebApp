using STLSitesWebApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.ViewModels.Category
{
    public class CategoryCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public void Persist(ApplicationDbContext context)
        {
            Models.Category category = new Models.Category
            {
                Name = this.Name,
            };
            context.Add(category);
            context.SaveChanges();
        }
    }
}
