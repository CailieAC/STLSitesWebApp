using Microsoft.AspNetCore.Mvc;
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
    public class LocationListItemViewModel
    {
        //[HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Location Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        [Display(Name = "County")]
        public County LocationCounty { get; set; }
        [Display(Name = "Average Rating")]
        public string AverageRating { get; set; }
        [Display(Name = "Number of Ratings")]
        public int NumberOfRatings { get; set; }

        public string Categories { get; set; }

        public static List<LocationListItemViewModel> GetLocations(ApplicationDbContext context)
        {
            return context.Locations
                .Include(p => p.Ratings)
                .Include(p=> p.CategoryLocations)
                .Select(p => new LocationListItemViewModel(p))
                .ToList();
        }

        public LocationListItemViewModel(Models.Location location)
        {
            this.Id = location.Id;
            this.Name = location.Name;
            this.Description = location.Description;
            this.Address = location.Address;
            this.LocationCounty = location.LocationCounty;
            this.AverageRating = GetAverageRating(location);
            this.NumberOfRatings = GetCount(location);
            this.Categories = GetCategories(location);
        }

        private string GetCategories(Models.Location location)
        {
            List<string> categoryNames = location.CategoryLocations
                .Select(cl => cl.Category)
                .Select(c => c.Name)
                .ToList();
            return String.Join(", ", categoryNames);

            //Alternate method to the above, if I am getting null errors
            //Would need to pass Application DbContext context into this method and the contructor method above
            //List<string> categoryNames = new List<string>();
            //List<int> CategoryIds = location.CategoryLocations.Select(cl => cl.CategoryId).ToList();
            //List<Models.Category> categories = context.Categories.Where(c => CategoryIds.Contains(c.Id)).ToList();
            //categoryNames = categories.Select(c => c.Name).ToList();
            //return String.Join(", ", categoryNames);
        }

        private static string GetAverageRating(Models.Location location)
        {
            string average = "none";
            int count = 0;
            int total = 0;
            if (location.Ratings != null)
            {
                foreach (LocationRating rating in location.Ratings)
                {
                    count++;
                    total += rating.Rating;
                }
                if (location.Ratings.Count > 0)
                {
                    average = (total/count).ToString();
                }
            }
            return average;
        }

        private static int GetCount(Models.Location location)
        {
            int count = 0;
            if (location.Ratings != null)
            {
                foreach (LocationRating rating in location.Ratings)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
