using Sports.API.Extensions;
using Sports.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddThirdPartyServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.Run();
