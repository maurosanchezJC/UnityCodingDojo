namespace CodingDojo7.Example2
{
    public class StubWeatherService : IWeatherService
    {
        public WeatherType CurrentWeather { get; set; } = WeatherType.Sunny;

        public WeatherType GetCurrentWeather() => CurrentWeather;
    }
}