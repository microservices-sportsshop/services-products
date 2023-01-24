using Sports.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependendServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureHttpRequestPipeline();

app.Run();


//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();

//    using var scope = app.Services.CreateScope();
//    using var context = scope.ServiceProvider.GetService<SportsShopDbContext>();
//    _ = (context?.Database.EnsureCreated());
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();
