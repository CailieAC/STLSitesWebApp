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

        [Required]
        public List<int> CategoryIds { get; set; }
        public List<Models.Category> Categories { get; set; }
        public IList<CategoryLocation> CategoryLocations { get; set; }

        [NotMapped]
        public List<SelectListItem> LocationCounties { get; set; }

        public LocationCreateViewModel() { }

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

                this.Categories = context.Categories.ToList();
            }

        public void Persist(ApplicationDbContext context)
        {
            Models.Location location = new Models.Location
            {
                Name = this.Name,
                Description = this.Description,
                Address = this.Address,
                LocationCounty = this.LocationCounty,
            };
            context.Locations.Add(location);
            
            List<CategoryLocation> categoryLocations = CreateManyToManyRelationships(location.Id);
            location.CategoryLocations = categoryLocations;

            //foreach (CategoryLocation categoryLocation in CategoryLocations)
            //{
            //    context.CategoryLocations.Add(categoryLocation);
            //}
            
            context.SaveChanges();
        }

        private List<CategoryLocation> CreateManyToManyRelationships(int locationId)
        {
            return CategoryIds.Select(catId => new CategoryLocation { LocationId = locationId, CategoryId = catId }).ToList();
        }
    }
}
