using System;

namespace CodingDojo8.Exercise
{
    public interface ITimeService
    {
        DateTime CurrentTime { get; }
        void UpdateTime();
    }
}