namespace CodingDojo7.Example2
{
    public enum WeatherType
    {
        Sunny,
        Cloudy,
        Rainy,
        Snowy,
        Stormy,
    }
    public interface IWeatherService
    {
        WeatherType GetCurrentWeather();
    }
}