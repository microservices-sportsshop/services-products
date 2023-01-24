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
            _ = modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId);

            modelBuilder.Seed();
        }

        public DbSet<Product> Products => Set<Product>();

        public DbSet<Category> Categories => Set<Category>();
    }

}