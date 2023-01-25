using Sports.Persistence;

namespace Sports.API.Extensions
{

    public static class HttpRequestPipelineExtensions
    {

        public static WebApplication ConfigureHttpRequestPipeline(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                using var scope = app.Services.CreateScope();
                using var context = scope.ServiceProvider.GetService<SportsShopDbContext>();
                _ = (context?.Database.EnsureCreated());
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }

}
