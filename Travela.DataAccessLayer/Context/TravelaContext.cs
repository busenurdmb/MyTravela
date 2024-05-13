using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTravela.EntityLayer.Concrete;

namespace MyTravela.DataAccessLayer.Context
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
        public DbSet<Feature> Features { get; set; }
    }
}
