using MonWeather.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MonWeather.Core.Interfaces;

namespace MonWeather.Infra
{
    public class CityRepository : ICityRepository
    {
        private readonly WeatherDbContext _context;

        public CityRepository(WeatherDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City?> GetCityById(int id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async Task AddCity(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }

        public async Task DelCityById(int id)
        {
            var city = await GetCityById(id);
            if (city != null)
            {
                _context.Cities.Remove(city);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCity(City city)
        {
            _context.Cities.Update(city);
            await _context.SaveChangesAsync();
        }
    }
}
