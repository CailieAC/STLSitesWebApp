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
        public string Name { get; set; }
        public string Description { get; set; }
        public List<LocationRating> Ratings { get; set; }
        public string Address { get; set; }
        public County LocationCounty { get; set; }

        public IList<CategoryLocation> CategoryLocations { get; set; }
    }
}
