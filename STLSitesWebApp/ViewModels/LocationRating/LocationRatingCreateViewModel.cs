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
            //TODO: Figure out how to add the new Rating item to the list of Ratings for a Location
            //The Ratings array does not exist yet. - need to re-set the database to have each item
            //start out with that array of Ratings objects? Or find a way to instantiate each location 
            //object with that.
            //Location locationToRate = context.Locations.SingleOrDefault(location => location.Id == LocationId);
            //    locationToRate.Ratings.Add(rating);

            context.Add(rating);
            context.SaveChanges();
        }
        
    }
}
