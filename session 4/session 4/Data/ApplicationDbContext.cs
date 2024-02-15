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
        public DbSet<BlogType> types { get; set; }
        public DbSet<Blog> blogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        modelBuilder.Entity<Company>().HasData(
            new Company {Id = 1 , Name="Niki"},
            new Company {Id = 2 , Name="Adidas"}
           
            );modelBuilder.Entity<BlogType>().HasData(
             new BlogType { Id = 1, Name = "comedy" },
            new BlogType { Id = 2, Name = "Romantic" },
            new BlogType { Id = 3, Name = "Action" }

            );
        }
    }

}
