using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STLSitesWebApp.Models
{
    public enum County
    {
        [Display(Name = "St. Charles")]
        StCharles,
        [Display(Name = "St. Clair")]
        StClair,
        [Display(Name = "St. Louis County")]
        StLouisCounty,
        [Display(Name = "St. Louis City")]
        StLouisCity,
        [Display(Name = "St. Francois")]
        StFrancois,
        Lincoln, Warren, Franklin, Jefferson, Monroe,
        Clinton, Madison, Jersey, Bond, Calhoun, Macoupin
    };
}
