using Microsoft.AspNetCore.Mvc.Rendering;
using STLSitesWebApp.Data;
using STLSitesWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.ViewModels.Location
{
    public class LocationEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string Name { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Street Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "County")]
        public County LocationCounty { get; set; }

        public List<int> CategoryIds { get; set; }
        public List<Models.Category> Categories { get; set; }

        [NotMapped]
        public List<SelectListItem> LocationCounties { get; set; }

        public LocationEditViewModel() { }

        public LocationEditViewModel(int id, ApplicationDbContext context)
        {
            Models.Location location = context.Locations.Find(id);
            this.Id = location.Id;
            this.Name = location.Name;
            this.Description = location.Description;
            this.Address = location.Address;
            this.LocationCounty = location.LocationCounty;
            this.Categories = context.Categories.ToList();
            this.CategoryIds = GetCategories(location, context);

            LocationCounties = new List<SelectListItem>();
            foreach (County county in Enum.GetValues(typeof(County)))
            {
                LocationCounties.Add(new SelectListItem
                {
                    Value = ((int)county).ToString(),
                    Text = county.ToString()
                });
            }
        }

        public void Persist(int locationId, ApplicationDbContext context)
        {
            //Below version updated a location while maintaining it's Id
            //Models.Location location = context.Locations.Find(this.Id);

            //location.Id = this.Id;
            //location.Name = this.Name;
            //location.Description = this.Description;
            //location.Address = this.Address;
            //location.LocationCounty = this.LocationCounty;

            //context.Update(location);

            //Below version creates a new location each time and deleted the old one

            Models.Location location = new Models.Location()
            {
                Name = this.Name,
                Description = this.Description,
                Address = this.Address,
                LocationCounty = this.LocationCounty
            };
            context.Locations.Remove(context.Locations.Find(Id));
            context.Add(location);

            List<CategoryLocation> categoryLocations = CreateManyToManyRelationships(location.Id);
            location.CategoryLocations = categoryLocations;
            context.SaveChanges();
        }

        private List<CategoryLocation> CreateManyToManyRelationships(int locationId)
        {
            return CategoryIds.Select(catId => new CategoryLocation { LocationId = locationId, CategoryId = catId }).ToList();
        }

        private List<int> GetCategories(Models.Location location, ApplicationDbContext context)
        {
            List<int> categoryIds = new List<int>();
            foreach (CategoryLocation categoryLocation in context.CategoryLocations)
            {
                if (categoryLocation.LocationId == location.Id)
                {
                    categoryIds.Add(categoryLocation.CategoryId);
                }
            }
            return categoryIds;
        }
    }
}
