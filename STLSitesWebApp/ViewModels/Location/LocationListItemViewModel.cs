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
        public int Id { get; set; }
        [Display(Name = "Location Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        //public List<int> Ratings { get; set; }

        //List<Location> locations = context.Locations.ToList();

        private ApplicationDbContext context;
        public LocationListItemViewModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        internal static List<Location> GetLocations(ApplicationDbContext context)
        {
            return context.Locations.ToList();
        }

        /*
        private static LocationListItemViewModel GetListItem(Location location)
        {
            return new LocationListItemViewModel
            {
                Id = location.Id,
                Name = location.Name,
                Description = location.Description,
            };
        }
        */
    }
}
