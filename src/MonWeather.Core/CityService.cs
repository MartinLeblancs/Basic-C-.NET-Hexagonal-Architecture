using MonWeather.Core.Interfaces;
using MonWeather.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonWeather.Core
{
    public class CityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public Task<IEnumerable<City>> GetAllCities()
        {
            return _cityRepository.GetAllCities();
        }

        public Task<City> GetCityById(int id)
        {
            return _cityRepository.GetCityById(id);
        }

        public Task AddCity(City city)
        {
            return _cityRepository.AddCity(city);
        }

        public Task DelCityById(int id)
        {
            return _cityRepository.DelCityById(id);
        }

        public Task UpdateCity(City city)
        {
            return _cityRepository.UpdateCity(city);
        }
    }
}
