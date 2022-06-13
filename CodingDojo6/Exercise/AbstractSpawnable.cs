namespace CodingDojo6.Exercise
{
    public abstract class AbstractSpawnable : ISpawnable
    {
        public abstract int FromHour { get; }
        public abstract int ToHour { get; }

        public bool CanSpawn(int currentHour)
        {
            return currentHour >= FromHour && currentHour <= ToHour;
        }
    }
}