using Sports.Dependencies;

namespace Sports.API.Extensions
{

    public static class DependendServiceExtensions
    {

        public static IServiceCollection AddDependendServices(this IServiceCollection services)
        {
            _ = services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            _ = services.AddEndpointsApiExplorer();
            _ = services.AddSwaggerGen();

            _ = services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

            _ = services.AddApplicationServices();

            return services;
        }

    }

}
