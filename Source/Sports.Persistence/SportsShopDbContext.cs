using Microsoft.EntityFrameworkCore;
using Sports.Data.Entities;
using Sports.Persistence.Extensions;

namespace Sports.Persistence
{

    public class SportsShopDbContext : DbContext
    {

        public SportsShopDbContext(DbContextOptions<SportsShopDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId);

            modelBuilder.Seed();
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }

}