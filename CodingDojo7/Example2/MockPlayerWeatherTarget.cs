namespace CodingDojo7.Example2
{
    public class MockPlayerWeatherTarget : IPlayer, IWeatherTarget
    {
        public enum MockState
        {
            NotAffected,
            AffectedByFavorableWeather,
            AffectedByUnfavorableWeather,
        }
        
        public int HealthPoints { get; set; }
        public int TotalLifePoints { get; set; }
        public int AttackPoints { get; set; }
        public int DefensePoints { get; set; }

        public MockState CurrentState { get; set; } = MockState.NotAffected;   

        public WeatherType FavorableWeather { get; set; }
        public WeatherType UnfavorableWeather { get; set; }
        
        public void OnFavorableWeather()
        {
            CurrentState = MockState.AffectedByFavorableWeather;
        }

        public void OnUnfavorableWeather()
        {
            CurrentState = MockState.AffectedByUnfavorableWeather;
        }
    }
}