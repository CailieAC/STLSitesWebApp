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
    public class LocationRatingCreateViewModel
    {
        //private string ratings = "12345";

        //public int Id { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public int Rating { get; set; }
        [Display(Name = "Description")]
        [Required]
        public string RatingDescription { get; set; }


        public void Persist(ApplicationDbContext context)
        {
            LocationRating rating = new LocationRating
            {
                LocationId = this.LocationId,
                Rating = this.Rating,
                RatingDescription = this.RatingDescription
            };
            context.Add(rating);
            context.SaveChanges();
        }
        
    }
}
