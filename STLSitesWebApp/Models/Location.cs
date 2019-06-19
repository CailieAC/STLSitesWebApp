using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STLSitesWebApp.Data;

namespace STLSitesWebApp.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<LocationRating> Ratings { get; set; }

        internal static List<Location> GetLocations(ApplicationDbContext context)
        {
            return context.Locations.ToList();
        }

        public void Persist(ApplicationDbContext context)
        {
            Location location = new Location
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description
            };
            context.Add(location);
            context.SaveChanges();
        }
    }
}
