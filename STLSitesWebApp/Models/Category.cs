using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<CategoryLocation> CategoryLocations { get; set; }
    }
}
