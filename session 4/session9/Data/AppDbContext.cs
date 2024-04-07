using Microsoft.EntityFrameworkCore;
using session9.Models;

namespace session9.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Company> companies { get; set; }
        public DbSet<Product> products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Niki" },
                new Company { Id = 2, Name = "Adidas" }

                );
        }

    }
}
