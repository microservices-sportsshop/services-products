using Microsoft.EntityFrameworkCore;
using Sports.Data.Entities;

namespace Sports.Persistence.Extensions
{
    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba411"), Name = "Active Wear - Men" },
                new Category { Id = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba412"), Name = "Active Wear - Women" },
                new Category { Id = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba413"), Name = "Mineral Water" },
                new Category { Id = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba414"), Name = "Publications" },
                new Category { Id = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba415"), Name = "Supplements" });

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba501"), CategoryId = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba411"), Name = "Grunge Skater Jeans", Sku = "AWMGSJ", Price = 68, IsAvailable = true },
                new Product { Id = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba502"), CategoryId = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba411"), Name = "Polo Shirt", Sku = "AWMPS", Price = 35, IsAvailable = true },
                new Product { Id = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba503"), CategoryId = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba411"), Name = "Skater Graphic T-Shirt", Sku = "AWMSGT", Price = 33, IsAvailable = true },
                new Product { Id = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba504"), CategoryId = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba411"), Name = "Slicker Jacket", Sku = "AWMSJ", Price = 125, IsAvailable = true },
                new Product { Id = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba505"), CategoryId = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba411"), Name = "Thermal Fleece Jacket", Sku = "AWMTFJ", Price = 60, IsAvailable = true },
                new Product { Id = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba506"), CategoryId = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba411"), Name = "Unisex Thermal Vest", Sku = "AWMUTV", Price = 95, IsAvailable = true },
                new Product { Id = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba507"), CategoryId = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba411"), Name = "V-Neck Pullover", Sku = "AWMVNP", Price = 65, IsAvailable = true },
                new Product { Id = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba508"), CategoryId = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba411"), Name = "V-Neck Sweater", Sku = "AWMVNS", Price = 65, IsAvailable = true },
                new Product { Id = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba509"), CategoryId = Guid.Parse("62042340-8b07-45c7-8e93-70ea318ba411"), Name = "V-Neck T-Shirt", Sku = "AWMVNT", Price = 17, IsAvailable = true }
                );

        }

    }
}
