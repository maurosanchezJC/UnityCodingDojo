using System;

namespace CodingDojo8.Exercise
{
    public interface ILogger
    {
        void Log(DateTime dateTime, string user, string message);
    }
}