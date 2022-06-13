using System;
using System.Collections.Generic;
using CodingDojo6;
using NUnit.Framework;

namespace CodingDojo6Tests
{
    [TestFixture]
    public class PlayerDataHandlerTests
    {
        private TestablePlayerDataHandler playerDataHandler;
        
        [SetUp]
        public void SetupPlayerDataHandler()
        {
            playerDataHandler = new TestablePlayerDataHandler();
        }
        
        [Test]
        public void CreateNewPlayer_DefiningPlayerName_ExpectsNewPlayer()
        {
            const string PLAYER_NAME = "NewPlayer";
            Player newPlayer = playerDataHandler.CreateNewPlayer(PLAYER_NAME);
            
            Assert.NotNull(newPlayer);
        }
        
        [Test]
        public void CreateNewPlayer_PlayerNameIsEmpty_ExpectsException()
        {
            Assert.Throws<Exception>(() => playerDataHandler.CreateNewPlayer(string.Empty));
        }
        
        [Test]
        public void CreateNewPlayer_PlayerNameIsNull_ExpectsException()
        {
            Assert.Throws<Exception>(() => playerDataHandler.CreateNewPlayer(null));
        }

        [Test]
        public void LoadPlayerDataFromCloud_CloudServiceNotConnected_ExpectsException()
        {
            StubCloudService stubCloudService = new StubCloudService();
            stubCloudService.SetStatus(StubCloudService.Status.Error);
            playerDataHandler.CloudService = stubCloudService;

            Assert.Throws<Exception>(() => playerDataHandler.LoadPlayerDataFromCloud());
        }

        [Test]
        public void LoadPlayerDataFromCloud_CloudServiceIsConnected_ExpectsPlayerData()
        {
            StubCloudService stubCloudService = new StubCloudService();
            
            stubCloudService.SetStatus(StubCloudService.Status.Connected);
            
            Dictionary<string, object> dummyData = GetDummyData();
            stubCloudService.DataToReturn = dummyData;
            
            playerDataHandler.CloudService = stubCloudService;

            Player loadedPlayer = playerDataHandler.LoadPlayerDataFromCloud();

            Assert.AreEqual(dummyData["name"], loadedPlayer.name);
        }

        [Test]
        public void SavePlayerDataOnCloud_ServiceIsNotConnected_ReturnsFalse()
        {
            StubCloudService stubCloudService = new StubCloudService();
            stubCloudService.SetStatus(StubCloudService.Status.Error);

            playerDataHandler.CloudService = stubCloudService;

            Player newPlayer = new Player() { name = "Dummy" };

            bool wasSaved = playerDataHandler.SavePlayerDataOnCloud(newPlayer);
            
            Assert.IsFalse(wasSaved);
        }
        
        [Test]
        public void SavePlayerDataOnCloud_ServiceIsConnected_ReturnsTrue()
        {
            StubCloudService stubCloudService = new StubCloudService();
            stubCloudService.SetStatus(StubCloudService.Status.Connected);

            Player newPlayer = playerDataHandler.CreateNewPlayer("Dummy");
            bool wasSaved = playerDataHandler.SavePlayerDataOnCloud(newPlayer);
            
            Assert.IsTrue(wasSaved);
        }

        private Dictionary<string, object> GetDummyData() => new Dictionary<string, object>()
        {
            { "name", "Dummy" },
            { "lifePoints", 10 },
            { "attackPoints", 10 },
            { "defensePoints", 10 },
        };
    }
}