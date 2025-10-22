using MonWeather.Models;

namespace  MonWeather.Core.Interfaces;
public interface ICityRepository
{
    IEnumerable<City> GetAllCities();
    City? GetCityById(int id);
    void AddCity(City city);
}
