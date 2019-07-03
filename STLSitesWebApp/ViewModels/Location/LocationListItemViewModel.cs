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
        public static List<LocationListItemViewModel> GetLocations(ApplicationDbContext context)
        {
            return context.Locations
                .Include(p => p.Ratings)
                .Select(p => new LocationListItemViewModel(p))
                .ToList();
        }

        public LocationListItemViewModel(Location location)
        {
            this.Id = location.Id;
            this.Name = location.Name;
            this.Description = location.Description;
            this.Address = location.Address;
            this.LocationCounty = location.LocationCounty;
            this.AverageRating = GetAverageRating(location);
            this.NumberOfRatings = GetCount(location);
        }

        //ToDO: Make sure this works...
        private static string GetAverageRating(Location location)
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

        private static int GetCount(Location location)
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

        //[HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Location Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public County LocationCounty { get; set; }
        public string AverageRating { get; set; }
        public int NumberOfRatings { get; set; }

    }
}
