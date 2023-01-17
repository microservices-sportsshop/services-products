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

        }

    }
}
