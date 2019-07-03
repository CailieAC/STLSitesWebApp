using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using STLSitesWebApp.Models;
using STLSitesWebApp.ViewModels;
using STLSitesWebApp.ViewModels.Location;

namespace STLSitesWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //DbSet maps to a location for the <class>
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationRating> LocationRatings { get; set; }

        //Add like this?
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        //TODO
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CategoryLocation>()
        //        .HasKey(loc => new { loc.LocationID, loc.CategoryID });
        //}
    }
}
