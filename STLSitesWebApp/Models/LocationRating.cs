using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.Models
{
    public class LocationRating
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int Rating { get; set; }
        public string RatingDescription { get; set; }
    }
}
