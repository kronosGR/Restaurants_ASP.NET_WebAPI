using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence;

public class RestaurantsDbContext:DbContext
{
    
    public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options):base(options){}
    
    internal DbSet<Restaurant> Restaurants {get; set;}
    internal DbSet<Dish> Dishes {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseMySql(
        //     "Host=kandz.me;Port=3306;Database=restaurants;Username=restaurants;Password=KnAXxnHGx4G3FhKc;",
        //     new MariaDbServerVersion(new Version(8,0,32)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Restaurant>().OwnsOne(r => r.Address);
        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Dishes)
            .WithOne()
            .HasForeignKey(d => d.RestaurantId);
    }
}