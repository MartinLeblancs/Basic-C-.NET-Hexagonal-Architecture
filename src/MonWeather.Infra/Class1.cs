using MonWeather.Models;
using MonWeather.Core.Interfaces;

namespace MonWeather.Infra;
public class InMemoryCityRepository : ICityRepository
{
    private readonly List<City> _cities = new List<City>();

    public InMemoryCityRepository()
    {
        _cities.Add(new City { Id = 1, Name = "Paris", Country = "France", Latitude = 48.8566, Longitude = 2.3522 });
        _cities.Add(new City { Id = 2, Name = "New York", Country = "USA", Latitude = 40.7128, Longitude = -74.006 });
        _cities.Add(new City { Id = 3, Name = "Tokyo", Country = "Japan", Latitude = 35.6762, Longitude = 139.6503 });
    }

    public IEnumerable<City> GetAllCities() => _cities;

    public City? GetCityById(int id) => _cities.FirstOrDefault(c => c.Id == id);

    public void AddCity(City city)
    {
        city.Id = _cities.Max(c => c.Id) + 1;
        _cities.Add(city);
    }
}
