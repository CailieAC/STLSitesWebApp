using Microsoft.AspNetCore.Mvc.Rendering;
using STLSitesWebApp.Data;
using STLSitesWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.ViewModels
{
    public class LocationCreateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Location")]
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Description { get; set; }
        [Display(Name = "Street Address")]
        public string Address { get; set; }
        [Display(Name = "County")]
        public County LocationCounty { get; set; }

        public int CategoryId { get; set; }
        public int LocationId { get; set; }
        public List<Models.Category> Categories { get; set; }

        public IList<CategoryLocation> CategoryLocations { get; set; }

        [NotMapped]
        public List<SelectListItem> LocationCounties { get; set; }

        public LocationCreateViewModel(ApplicationDbContext context)
        {
            LocationCounties = new List<SelectListItem>();

            foreach (County county in Enum.GetValues(typeof(County)))
            {
                LocationCounties.Add(new SelectListItem
                {
                    Value = ((int)county).ToString(),
                    Text = county.ToString()
                });
            }

            List<Models.Category> categories = context.Categories.ToList();
            this.Categories = categories;
        }

        public void Persist(ApplicationDbContext context)
        {
            CategoryLocation categoryLocation = new CategoryLocation
            {
                CategoryId = this.CategoryId,
                Category = this.Category,

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }


            Models.Location location = new Models.Location
            {
                Name = this.Name,
                Description = this.Description,
                Address = this.Address,
                LocationCounty = this.LocationCounty,

            };
            context.Add(location);
            context.SaveChanges();
        }
    }
}
