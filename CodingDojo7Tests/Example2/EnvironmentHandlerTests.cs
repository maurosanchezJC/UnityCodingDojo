using System;
using CodingDojo7.Example2;
using NUnit.Framework;

namespace CodingDojo7Tests.Example2
{
    public class EnvironmentHandlerTests
    {
        private EnvironmentHandler environmentHandler = new EnvironmentHandler();
        
        [SetUp]
        public void SetupEnvironmentHandler()
        {
            environmentHandler = new EnvironmentHandler();
        }

        [Test]
        public void AffectPlayer_PlayerIsNull_ExpectsException()
        {
            Assert.Throws<Exception>(() => environmentHandler.AffectPlayer(null));
        }

        [Test]
        public void AffectPlayer_PlayerIsNotWeatherTarget_ExpectsException()
        {
            MockPlayer mockPlayer = new MockPlayer();
            Assert.Throws<Exception>(() => environmentHandler.AffectPlayer(mockPlayer));
        }
        
        [Test]
        public void AffectPlayer_WeatherIsSettled_PlayerIsNotAffectedByWeather()
        {
            MockPlayerWeatherTarget mockPlayer = new MockPlayerWeatherTarget();
            
            StubWeatherService stubWeatherService = new StubWeatherService();
            environmentHandler.SetWeatherService(stubWeatherService);
            
            mockPlayer.FavorableWeather = WeatherType.Rainy;
            
            environmentHandler.AffectPlayer(mockPlayer);
            Assert.AreNotEqual(mockPlayer.CurrentState, MockPlayerWeatherTarget.MockState.NotAffected);
        }
        
        [Test]
        public void AffectPlayer_WeatherIsFavorableForPlayer_PlayerIsAffectedByFavorableWeather()
        {
            MockPlayerWeatherTarget mockPlayer = new MockPlayerWeatherTarget();
            
            StubWeatherService stubWeatherService = new StubWeatherService();
            environmentHandler.SetWeatherService(stubWeatherService);
            
            mockPlayer.FavorableWeather = WeatherType.Rainy;
            stubWeatherService.CurrentWeather = WeatherType.Rainy;
            
            environmentHandler.AffectPlayer(mockPlayer);
            
            Assert.AreEqual(MockPlayerWeatherTarget.MockState.AffectedByFavorableWeather,mockPlayer.CurrentState);
        }
        
        [Test]
        public void AffectPlayer_WeatherIsUnfavorableForPlayer_PlayerIsAffectedByUnfavorableWeather()
        {
            MockPlayerWeatherTarget mockPlayer = new MockPlayerWeatherTarget();
            
            StubWeatherService stubWeatherService = new StubWeatherService();
            environmentHandler.SetWeatherService(stubWeatherService);
            
            mockPlayer.UnfavorableWeather = WeatherType.Rainy;
            stubWeatherService.CurrentWeather = WeatherType.Rainy;
            
            environmentHandler.AffectPlayer(mockPlayer);
            
            Assert.AreEqual(MockPlayerWeatherTarget.MockState.AffectedByUnfavorableWeather, mockPlayer.CurrentState);
        }
    }
}