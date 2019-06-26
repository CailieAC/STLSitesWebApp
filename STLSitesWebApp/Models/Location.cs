using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using STLSitesWebApp.Data;

namespace STLSitesWebApp.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Display (Name="Location")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        //public List<LocationRating> Ratings { get; set; }
        //public string Address { get; set; }

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

        //public void Persist(int id, ApplicationDbContext context)
        //{
        //    Location location = new Location
        //    {
        //        Id = id,
        //        Name = this.Name,
        //        Description = this.Description,
        //    };
        //    context.Add(location);
        //    context.SaveChanges();
        //}
    }
}
