using STLSitesWebApp.Data;
using STLSitesWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.ViewModels
{
    public class LocationCreateViewModel
    {
        //public int Id { get; set; }
        [Display(Name = "Location")]
        [Required]
        public string Name { get; set; }
        [Required]
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
