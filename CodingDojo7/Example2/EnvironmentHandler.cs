using System;

namespace CodingDojo7.Example2
{
    public class EnvironmentHandler
    {
        private IWeatherService weatherService;

        private IWeatherService WeatherService
        {
            get
            {
                if (weatherService == null)
                {
                    weatherService = new WeatherService();
                }

                return weatherService;
            }
            set => weatherService = value;
        }

        public void SetWeatherService(IWeatherService weatherService)
        {
            WeatherService = weatherService;
        }

        public void AffectPlayer(IPlayer player)
        {
            if (player == null)
            {
                throw new Exception("The given player is null so it can't be affected!");
            }
            
            if (!(player is IWeatherTarget weatherTarget))
            {
                throw new Exception("The given player is not a weather target!");
            }
            
            WeatherType currentWeather = weatherService.GetCurrentWeather();
            
            if (weatherTarget.FavorableWeather == currentWeather)
            {
                weatherTarget.OnFavorableWeather();
            }
            else if (weatherTarget.UnfavorableWeather == currentWeather)
            {
                weatherTarget.OnUnfavorableWeather();
            }
        }
    }
}