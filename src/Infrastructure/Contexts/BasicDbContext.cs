using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class BasicDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasOne(e => e.ParentCategory)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }

        public BasicDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
