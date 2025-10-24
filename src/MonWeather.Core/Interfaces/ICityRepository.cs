using MonWeather.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonWeather.Core.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCities();
        Task<City> GetCityById(int id);
        Task AddCity(City city);
        Task DelCityById(int id);
        Task UpdateCity(City city);
    }
}
