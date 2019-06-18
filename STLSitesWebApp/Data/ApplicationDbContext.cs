using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using STLSitesWebApp.Models;

namespace STLSitesWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //DbSet maps to a location for the <class>
        public DbSet<Location> Locations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
