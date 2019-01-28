using Microsoft.EntityFrameworkCore;
using Kitenest.Models;



namespace Kitenest.Data
{
    public class KitenestDbContext : DbContext
    {
        
        public KitenestDbContext(DbContextOptions<KitenestDbContext> options) : base(options) { }


        public DbSet<School> School { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Continent> Continent { get; set; }
        public DbSet<SchoolTime> SchoolTime { get; set; }


    }
}
