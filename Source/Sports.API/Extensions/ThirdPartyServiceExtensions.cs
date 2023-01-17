using Microsoft.EntityFrameworkCore;
using Sports.Persistence;

namespace Sports.API.Extensions
{

    public static class ThirdPartyServiceExtensions
    {

        public static IServiceCollection AddThirdPartyServices(this IServiceCollection services)
        {
            _ = services.AddDbContext<SportsShopDbContext>(options =>
            {
                _ = options.UseInMemoryDatabase("SportsShop");
            });

            _ = services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            _ = services.AddEndpointsApiExplorer();
            _ = services.AddSwaggerGen();

            _ = services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

            return services;
        }

    }

}
