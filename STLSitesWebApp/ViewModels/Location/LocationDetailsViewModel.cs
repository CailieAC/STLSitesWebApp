using Microsoft.EntityFrameworkCore;
using STLSitesWebApp.Data;
using STLSitesWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.ViewModels
{
    public class LocationDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name="Street Address")]
        public string Address { get; set; }
        [Display(Name = "County")]
        public County LocationCounty { get; set; }
        public List<LocationRating> Ratings { get; set; }

        public string Categories { get; set; }

        public static LocationDetailsViewModel GetLocation(int locationId, ApplicationDbContext context)
        {

            Models.Location location = context.Locations
                .Include(p => p.Ratings)
                .SingleOrDefault(p => p.Id == locationId);
            LocationDetailsViewModel viewModel = new LocationDetailsViewModel(location, context);
            return viewModel;
            //return context.Locations
            //    .Include(p => p.Ratings)
            //    //.Include(p=>p.CategoryLocations)
            //    .Select(p => new LocationDetailsViewModel(p, context))
            //    .SingleOrDefault(p => p.Id == locationId);
        }

        public LocationDetailsViewModel(Models.Location location, ApplicationDbContext context)
        {
            this.Id = location.Id;
            this.Name = location.Name;
            this.Description = location.Description;
            this.Address = location.Address;
            this.LocationCounty = location.LocationCounty;
            this.Ratings = location.Ratings;
            this.Categories = GetCategories(location, context);
        }

        public LocationDetailsViewModel()
        {
            
        }

        private string GetCategories(Models.Location location, ApplicationDbContext context)
        {
            List<string> categoryNames = new List<string>();
            foreach (CategoryLocation categoryLocation in context.CategoryLocations)
            {
                if(categoryLocation.LocationId == location.Id)
                {
                    int categoryId = categoryLocation.CategoryId;
                    Models.Category category = context.Categories.SingleOrDefault(c => c.Id == categoryId);
                    categoryNames.Add(category.Name);
                }
            }
            
            return string.Join(", ", categoryNames);


            //List<string> categoryNames = location.CategoryLocations
            //    .Select(cl => cl.Category)
            //    .Select(c => c.Name)
            //    .ToList();

            //Alternate method to the above, if I am getting null errors
            //Would need to pass Application DbContext context into this method and the contructor method above
            //List<string> categoryNames = new List<string>();
            //List<int> CategoryIds = location.CategoryLocations.Select(cl => cl.CategoryId).ToList();
            //List<Models.Category> categories = context.Categories.Where(c => CategoryIds.Contains(c.Id)).ToList();
            //categoryNames = categories.Select(c => c.Name).ToList();
            //return String.Join(", ", categoryNames);
        }
    }
}
