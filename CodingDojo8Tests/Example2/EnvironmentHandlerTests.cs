using NUnit.Framework;
using NSubstitute;
using CodingDojo7.Example2;
using System;

namespace CodingDojo8Tests.Example2
{
    [TestFixture]
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
            IPlayer mockPlayer = Substitute.For<IPlayer>();
            Assert.Throws<Exception>(() => environmentHandler.AffectPlayer(mockPlayer));
        }
        
        public interface IPlayerWeatherTarget : IPlayer, IWeatherTarget { }
        
        [Test]
        public void AffectPlayer_WeatherIsSettled_PlayerIsNotAffectedByWeather()
        {
            IPlayerWeatherTarget mockPlayer = Substitute.For<IPlayerWeatherTarget>();
            IWeatherService stubWeatherService = Substitute.For<IWeatherService>();

            stubWeatherService.GetCurrentWeather().Returns(WeatherType.Sunny);
            mockPlayer.FavorableWeather.Returns(WeatherType.Rainy);
            mockPlayer.UnfavorableWeather.Returns(WeatherType.Rainy);

            bool wasAffected = false;

            mockPlayer.When(mock => mock.OnFavorableWeather()).Do(x => { wasAffected = true; });
            mockPlayer.When(mock => mock.OnUnfavorableWeather()).Do(x => { wasAffected = true; });
            
            environmentHandler.SetWeatherService(stubWeatherService);
            environmentHandler.AffectPlayer(mockPlayer);

            Assert.IsFalse(wasAffected);
        }
        
        [Test]
        public void AffectPlayer_WeatherIsFavorableForPlayer_PlayerIsAffectedByFavorableWeather()
        {
            IPlayerWeatherTarget mockPlayer = Substitute.For<IPlayerWeatherTarget>();
            IWeatherService stubWeatherService = Substitute.For<IWeatherService>();

            stubWeatherService.GetCurrentWeather().ReturnsForAnyArgs(WeatherType.Rainy, WeatherType.Cloudy);
            stubWeatherService.GetCurrentWeather().Returns(WeatherType.Rainy, WeatherType.Cloudy);
            mockPlayer.FavorableWeather.Returns(WeatherType.Rainy);

            bool wasAffectedByFavorableWeather = false;

            mockPlayer.When(mock => mock.OnFavorableWeather()).Do(x => { wasAffectedByFavorableWeather = true; });
            
            environmentHandler.SetWeatherService(stubWeatherService);
            environmentHandler.AffectPlayer(mockPlayer);

            Assert.IsTrue(wasAffectedByFavorableWeather);
        }
        
        [Test]
        public void AffectPlayer_WeatherIsUnfavorableForPlayer_PlayerIsAffectedByUnfavorableWeather()
        {
            IPlayerWeatherTarget mockPlayer = Substitute.For<IPlayerWeatherTarget>();
            IWeatherService stubWeatherService = Substitute.For<IWeatherService>();

            stubWeatherService.GetCurrentWeather().Returns(WeatherType.Rainy);
            mockPlayer.UnfavorableWeather.Returns(WeatherType.Rainy);
            
            environmentHandler.SetWeatherService(stubWeatherService);
            environmentHandler.AffectPlayer(mockPlayer);

            mockPlayer.Received().OnUnfavorableWeather();
        }
    }
}