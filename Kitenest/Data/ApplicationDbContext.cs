using System;
using System.Collections.Generic;
using System.Text;
using Kitenest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kitenest.Data
{
    public class KitenestDbContext : IdentityDbContext<ApplicationUser>
    {
        public KitenestDbContext(DbContextOptions<KitenestDbContext> options)
            : base(options)
        {

        }
        public DbSet<School> School { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Continent> Continent { get; set; }
        public DbSet<SchoolTime> SchoolTime { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
