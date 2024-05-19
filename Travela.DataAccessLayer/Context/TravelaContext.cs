using Microsoft.EntityFrameworkCore;
using Travela.EntityLayer.Concrete;

namespace Travela.DataAccessLayer.Context
{
    public class TravelaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-493DFJA\\SQLEXPRESS; initial catalog=TravelaDb;integrated security=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutFeatures> AboutFeatures { get; set; }
        public DbSet<Feature> Features { get; set; }
    }
}
