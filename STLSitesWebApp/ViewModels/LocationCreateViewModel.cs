using STLSitesWebApp.Data;
using STLSitesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.ViewModels
{
    public class LocationCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void Persist(ApplicationDbContext context)
        {
            Location location = new Location
            {
                Name = this.Name,
                Description = this.Description,
            };
            context.Add(location);
            context.SaveChanges();
        }
    }
}
