namespace MonWeather.Models;
public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public required City City { get; set; }
    public int TemperatureC { get; set;}
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public required string Summary { get; set; }
}

public class City
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}