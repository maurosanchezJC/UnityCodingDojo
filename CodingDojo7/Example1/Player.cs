using System;

namespace CodingDojo7.Example1
{
    public class Player
    {
        protected IChatHandler chatHandler;

        protected virtual IChatHandler GetChatHandler() => new ChatHandler();

        public Player()
        {
            chatHandler = GetChatHandler();
        }
            
        public void SendMessage(string log)
        {
            if (string.IsNullOrEmpty(log))
            {
                throw new Exception("You can't send an empty message!");
            }
                
            chatHandler.SendMessage(log);
        }
    }
}