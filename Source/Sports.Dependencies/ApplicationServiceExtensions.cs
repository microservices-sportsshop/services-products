using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sports.Persistence;

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

            //_ = services.AddScoped<ICoursesBusiness, CoursesBusiness>();

            //_ = services.AddScoped<ICoursesRepository, CoursesRepository>();

            return services;
        }

    }

}