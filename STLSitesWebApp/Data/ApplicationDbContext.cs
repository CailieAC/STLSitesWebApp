using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using STLSitesWebApp.Models;
using STLSitesWebApp.ViewModels;
using STLSitesWebApp.ViewModels.Location;
using STLSitesWebApp.ViewModels.Category;

namespace STLSitesWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //DbSet maps to a location for the <class>
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationRating> LocationRatings { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryLocation> CategoryLocations { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CategoryLocation>()
                .HasKey(loc => new { loc.LocationId, loc.CategoryId });
        }
        

        public DbSet<STLSitesWebApp.ViewModels.Category.CategoryCreateViewModel> CategoryCreateViewModel { get; set; }
    }
}
