using System;
using NUnit.Framework;
using NSubstitute;
using CodingDojo7.Example1;
using TestablePlayer = CodingDojo8.Example1.TestablePlayer;

namespace CodingDojo8Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private TestablePlayer player;
        
        [SetUp]
        public void SetupPlayer()
        {
            player = new TestablePlayer();
        }
        
        [Test]
        public void SendMessage_SendingEmptyMessage_ExpectsException()
        {
            Assert.Throws<Exception>(() => player.SendMessage(string.Empty));
        }
        
        [Test]
        public void SendMessage_SendingNullMessage_ExpectsException()
        {
            Assert.Throws<Exception>(() => player.SendMessage(null));
        }
        
        //Inside this test, we assert against the mock element in consecuence of the object behavior.
        [Test]
        public void SendMessage_SendingDummyMessage_ChatHandlerReceivesMessage()
        {
            IChatHandler chatHandler = Substitute.For<IChatHandler>();
            player.ChatHandler = chatHandler;
            
            const string TEST_MESSAGE = "Sending test message.";
            player.SendMessage(TEST_MESSAGE);
            
            chatHandler.Received().SendMessage(TEST_MESSAGE);
        }
    }
}