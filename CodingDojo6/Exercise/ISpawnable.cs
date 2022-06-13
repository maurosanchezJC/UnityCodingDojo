namespace CodingDojo6.Exercise
{
    public interface ISpawnable
    {
        int FromHour { get; }
        int ToHour { get; }
        bool CanSpawn(int currentHour);
    }
}