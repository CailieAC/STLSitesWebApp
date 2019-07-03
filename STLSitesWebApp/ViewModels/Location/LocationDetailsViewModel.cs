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
        public List<LocationRating> Ratings { get; set; }

        public static LocationDetailsViewModel GetLocation(int? id, ApplicationDbContext context)
        {
            return context.Locations
                .Include(p => p.Ratings)
                .Select(p => new LocationDetailsViewModel(p))
                .SingleOrDefault(p => p.Id == id);
        }

        public LocationDetailsViewModel(Location location)
        {
            this.Id = location.Id;
            this.Name = location.Name;
            this.Description = location.Description;
            this.Address = location.Address;
            this.Ratings = location.Ratings;
        }

        public LocationDetailsViewModel()
        {
            
        }

    }
}
