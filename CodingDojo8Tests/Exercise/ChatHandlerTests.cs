using NUnit.Framework;

namespace CodingDojo8Tests.Exercise
{
    [TestFixture]
    public class ChatHandlerTests
    {
        private TestableChatHandler chatHandler;
        
        [SetUp]
        public void SetupChatHandler()
        {
            chatHandler = new TestableChatHandler();
        }

        [Test]
        public void SendMessage_MessageIsNull_ExpectsException()
        {
            
        }
        
        [Test]
        public void SendMessage_MessageIsEmpty_ExpectsException()
        {
            
        }
        
        [Test]
        public void SendMessage_MessageHasUnsupportedWords_ExpectsException()
        {
            
        }
        
        [Test]
        public void SendMessage_CleanMessageButUsernameNotSettled_ExpectsGuestAsUserOnLogger()
        {
            
        }
        
        [Test]
        public void SendMessage_CleanMessageAndUsernameSettled_ExpectsUserMessageOnLogger()
        {
            
        }

        [Test]
        public void AddUnsupportedWords_AddingNewWord_ExpectWordAddedToList()
        {
            
        }
        
        [Test]
        public void AddUnsupportedWords_AddingRepeatedWord_ExpectWordNotRepeated()
        {
            
        }
        
        [Test]
        public void AddUnsupportedWords_AddingRepeatedWordWithCaps_ExpectWordNotRepeated()
        {
            
        }
        
        [Test]
        public void AddUnsupportedWords_AddingRepeatedWordWithMayus_ExpectWordNotRepeated()
        {
            
        }
        
        [Test]
        public void AddUnsupportedWords_AddingMultipleNewWords_ExpectWordsAddedToList()
        {
            
        }
        
        [Test]
        public void AddUnsupportedWords_AddingMultipleRepeatedWords_ExpectWordsNotRepeated()
        {
            
        }
        
        [Test]
        public void AddUnsupportedWords_AddingSomeNewWordsAndSomeRepeatedWords_ExpectOnlyNewWordsAdded()
        {
            
        }
        
        [Test]
        public void SetUser_UsernameNotSettled_ExpectsGuestAsUser()
        {
            
        }
        
        [Test]
        public void SetUser_UsernameSettled_ExpectsUsername()
        {
            
        }
        
        [Test]
        public void SetUser_SettingEmptyUser_ExpectsGuestAsUser()
        {
            
        }

        [Test]
        public void IsChatEnabled_TimeIsOutOfScope_ExpectsFalse()
        {
            
        }
        
        [Test]
        public void IsChatEnabled_TimeIsOnScope_ExpectsTrue()
        {
            
        }
        
        [Test]
        public void SetActiveTime_SettingFromHs_HourIsSettled()
        {
            
        }
        
        [Test]
        public void SetActiveTime_SettingToHs_HourIsSettled()
        {
            
        }
    }
}