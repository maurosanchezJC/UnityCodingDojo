namespace CodingDojo7.Example2
{
    public interface IWeatherTarget
    {
        WeatherType FavorableWeather { get; }
        WeatherType UnfavorableWeather { get; }

        void OnFavorableWeather();
        void OnUnfavorableWeather();
    }
}