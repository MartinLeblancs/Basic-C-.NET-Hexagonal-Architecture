using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace MonWeather.Infra
{
    public class WeatherDbContextFactory
    {
        public static WeatherDbContext CreateDbContext()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<WeatherDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new WeatherDbContext(optionsBuilder.Options);
        }
    }
}
