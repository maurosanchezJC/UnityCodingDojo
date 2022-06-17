using System.Collections.Generic;

namespace CodingDojo7.Example2
{
    public class Warrior : IPlayer, IWeatherTarget
    {
        public Warrior(Dictionary<string, object> data)
        {
            HealthPoints = (int)data["healthPoints"];
            TotalLifePoints = (int)data["totalLifePoints"];
            AttackPoints = (int)data["attackPoints"];
            DefensePoints = (int)data["defensePoints"];
        }
            
        public WeatherType FavorableWeather { get; }
        public WeatherType UnfavorableWeather { get; }

        public int HealthPoints { get; private set; }
        public int TotalLifePoints { get; private set; }
        public int AttackPoints { get; private set; }
        public int DefensePoints { get; private set; }
        
        
        public void OnFavorableWeather()
        {
            AttackPoints = (int)(AttackPoints * 1.2f);
            DefensePoints = (int)(AttackPoints * 1.2f);
        }

        public void OnUnfavorableWeather()
        {
            AttackPoints = (int)(AttackPoints * 0.8f);
            DefensePoints = (int)(AttackPoints * 0.8f);
        }
    }
}