using Microsoft.EntityFrameworkCore;
using Restaurants.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<RestaurantsDbContext>(options =>
    options.UseMySql(
        "Host=kandz.me;Port=3306;Database=restaurants;Username=restaurants;Password=KnAXxnHGx4G3FhKc;",
        new MariaDbServerVersion(new Version(8,0,32))));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();