﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using STLSitesWebApp.Models;
using STLSitesWebApp.ViewModels;

namespace STLSitesWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //DbSet maps to a location for the <class>
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationRating> LocationRatings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<STLSitesWebApp.ViewModels.LocationListItemViewModel> LocationListItemViewModel { get; set; }

        public DbSet<STLSitesWebApp.ViewModels.LocationCreateViewModel> LocationCreateViewModel { get; set; }

        public DbSet<STLSitesWebApp.Models.LocationRating> LocationRating { get; set; }
    }
}
