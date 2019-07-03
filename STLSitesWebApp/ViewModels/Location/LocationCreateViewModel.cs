using Microsoft.AspNetCore.Mvc.Rendering;
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
        [StringLength(200, MinimumLength = 2)]
        public string Description { get; set; }
        [Display(Name = "Street Address")]
        public string Address { get; set; }
        public County LocationCounty { get; set; }
        public List<SelectListItem> LocationCounties { get; set; }

        public LocationCreateViewModel()
        {
            LocationCounties = new List<SelectListItem>();

            foreach (County county in Enum.GetValues(typeof(County)))
            {
                LocationCounties.Add(new SelectListItem
                {
                    Value = ((int)county).ToString(),
                    Text = county.ToString()
                });
            }
        }

        public void Persist(ApplicationDbContext context)
        {
            Location location = new Location
            {
                Name = this.Name,
                Description = this.Description,
                Address = this.Address,
                LocationCounty = this.LocationCounty
            };
            context.Add(location);
            context.SaveChanges();
        }
    }
}
