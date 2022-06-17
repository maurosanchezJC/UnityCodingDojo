using System;

namespace CodingDojo7.Example1
{
    public class ChatHandler :IChatHandler
    {
        public void SendMessage(string log)
        {
            //Let's imagine that this ChatHandler sends a message to an online server
            Console.WriteLine(log);
        }
    }
}