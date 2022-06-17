using System;

namespace CodingDojo7.Example2
{
    public class WeatherService : IWeatherService
    {
        public WeatherType GetCurrentWeather()
        {
            //Let's imagine this  method return a WeatherType depending on the result of an API.
            Random random = new Random();
            int valuesAmount = Enum.GetNames(typeof(WeatherType)).Length;
            int value = random.Next(valuesAmount);

            return (WeatherType)value;
        }
    }
}