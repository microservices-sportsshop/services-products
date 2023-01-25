using Sports.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependendServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureHttpRequestPipeline();

app.Run();
