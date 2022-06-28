using CodingDojo7.Example1;

namespace CodingDojo8.Example1
{
    public class TestablePlayer : Player
    {
        public IChatHandler ChatHandler
        {
            get => chatHandler;
            set => chatHandler = value;
        }
    }
}