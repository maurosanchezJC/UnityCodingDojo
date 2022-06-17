namespace CodingDojo7.Example1
{
    public class MockChatHandler : IChatHandler
    {
        public string LastMessageSent { get; private set; }
            
        public void SendMessage(string log)
        {
            LastMessageSent = log;
        }
    }
}