using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.Models
{
    public class CategoryLocation
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
