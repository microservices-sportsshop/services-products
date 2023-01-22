using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sports.ApplicationCore.Interfaces;
using Sports.Business;
using Sports.Configuration;
using Sports.Persistence;
using Sports.Repositories;

namespace Sports.Dependencies
{

    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            _ = services.AddDbContext<SportsShopDbContext>(options =>
            {
                _ = options.UseInMemoryDatabase("SportsShop");
            });

            _ = services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            _ = services.AddScoped<IProductsBusiness, ProductsBusiness>();

            _ = services.AddScoped<IProductsRepository, ProductsRepository>();

            return services;
        }

    }

}