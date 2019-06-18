using STLSitesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.ViewModels
{
    public class LocationCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /*
        public void Persist(STLSitesWebAppDbContext context)
        {
            Location location = new Location
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
            };
            context.Add(location);
            context.SaveChanges();
        }
        */
    }
}
