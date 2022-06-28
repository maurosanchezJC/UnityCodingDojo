using System;

namespace CodingDojo8.Exercise
{
    public class ChatLogger : ILogger
    {
        public void Log(DateTime dateTime, string user, string message)
        {
            Console.WriteLine($"[{dateTime}] {user}: {message}");
        }
    }
}