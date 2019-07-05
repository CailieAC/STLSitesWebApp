using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.Models
{
    public class CategoryLocation
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Category Category { get; set; }
    }
}
