using Microsoft.EntityFrameworkCore;
using MonWeather.Models;

namespace MonWeather.Infra
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; } = null!;
    }
}
