using Microsoft.EntityFrameworkCore;
using session_4.Models;
using System.Reflection.Emit;
using session_4.Models;
using session_4.Data;

namespace session_4.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }

        public DbSet<Company> companies { get; set; }
        public DbSet<Product> products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        modelBuilder.Entity<Company>().HasData(
            new Company {Id = 1 , Name="Niki"},
            new Company {Id = 2 , Name="Adidas"}
    
            );
        }
    }

}
