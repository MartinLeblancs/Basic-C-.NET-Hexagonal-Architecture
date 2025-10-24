using Microsoft.AspNetCore.Mvc;
using MonWeather.Core;
using MonWeather.Models;

namespace MonWeather.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    private readonly CityService _cityService;

    public CityController(CityService cityService)
    {
        _cityService = cityService;
    }

    // GET: /City
    [HttpGet(Name = "GetAllCities")]
    [ProducesResponseType(typeof(IEnumerable<City>), 200)]
    public ActionResult<IEnumerable<City>> Get()
    {
        var cities = _cityService.GetAllCities();
        return Ok(cities);
    }

    // GET: /City/{id}
    [HttpGet("{id}", Name = "GetCityById")]
    [ProducesResponseType(typeof(City), 200)]
    [ProducesResponseType(404)]
    public ActionResult<City> GetCityById(int id)
    {
        var city = _cityService.GetCityById(id);
        if (city == null)
            return NotFound();

        return Ok(city);
    }

    // POST: /City
    [HttpPost(Name = "PostCity")]
    [ProducesResponseType(typeof(City), 201)]
    [ProducesResponseType(400)]
    public ActionResult<City> Post([FromBody] City city)
    {
        if (city == null)
            return BadRequest();

        _cityService.AddCity(city);
        return CreatedAtAction(nameof(GetCityById), new { id = city.Id }, city);
    }

    // DELETE: /City/{id}
    [HttpDelete("{id}", Name = "DelCity")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult Delete(int id)
    {
        var city = _cityService.GetCityById(id);
        if (city == null)
            return NotFound();

        _cityService.DelCityById(id);
        return NoContent();
    }

    // PUT: /City/{id}
    [HttpPut("{id}", Name = "UpdateCity")]
    [ProducesResponseType(typeof(City), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public ActionResult<City> Put(int id, [FromBody] City city)
    {
        if (city == null)
            return BadRequest();

        var existingCity = _cityService.GetCityById(id);
        if (existingCity == null)
            return NotFound();

        city.Id = id;
        _cityService.UpdateCity(city);
        return Ok(city);
    }
}
