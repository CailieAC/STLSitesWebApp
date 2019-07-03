using Microsoft.AspNetCore.Mvc.Rendering;
using STLSitesWebApp.Data;
using STLSitesWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.ViewModels.Location
{
    public class LocationEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string Name { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Street Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "County")]
        public County LocationCounty { get; set; }

        [NotMapped]
        public List<SelectListItem> LocationCounties { get; set; }

        public LocationEditViewModel()
        {  
        }

        public LocationEditViewModel(int id, ApplicationDbContext context)
        {
            Models.Location location = context.Locations.Find(id);
            this.Id = location.Id;
            this.Name = location.Name;
            this.Description = location.Description;
            this.Address = location.Address;
            this.LocationCounty = location.LocationCounty;

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

        public void Persist(int locationId, ApplicationDbContext context)
        {
            Models.Location location = context.Locations.Find(this.Id);

            location.Id = this.Id;
            location.Name = this.Name;
            location.Description = this.Description;
            location.Address = this.Address;
            location.LocationCounty = this.LocationCounty;

            context.Update(location);
            context.SaveChanges();
        }
    }
}
