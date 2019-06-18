using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.ViewModels
{
    public class LocationRatingCreateViewModel
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int Rating { get; set; }
        public string RatingDescription { get; set; }

        /*
        public void Persist(MoviesDbContext context)
        {
            LocationRating rating = new LocationRating
            {
                LocationId = this.LocationId,
                Rating = this.Rating
                RatingDescription = this.RatingDescription
            };
            context.Add(rating);
            context.SaveChanges();
        }
        */
    }
}
