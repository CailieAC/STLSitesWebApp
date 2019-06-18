using STLSitesWebApp.Data;
using STLSitesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.ViewModels
{
    public class LocationListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private ApplicationDbContext context;
        public LocationListItemViewModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        //internal static List<LocationListItemViewModel> GetLocations(ApplicationDbContext context)
        //{
        //    return context.Locations;
                
        //        .GetModels()
        //        .Select(d => GetListItem(d))
        //        .ToList();
        //}

        //private static LocationListItemViewModel GetListItem(Location location)
        //{
        //    return new LocationListItemViewModel
        //    {
        //        Id = location.Id,
        //        Name = location.Name,
        //        Description = location.Description,
        //    };
        //}
    }
}
