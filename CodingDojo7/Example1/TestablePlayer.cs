namespace CodingDojo7.Example1
{
    public class TestablePlayer : Player
    {
            
        public MockChatHandler ChatHandler => (MockChatHandler)chatHandler;
        protected override IChatHandler GetChatHandler() => new MockChatHandler();
    }
}