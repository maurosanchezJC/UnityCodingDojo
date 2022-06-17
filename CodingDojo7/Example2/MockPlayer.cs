namespace CodingDojo7.Example2
{
    public class MockPlayer : IPlayer
    {
        public int HealthPoints { get; } = 0;
        public int TotalLifePoints { get; } = 0;
        public int AttackPoints { get; } = 0;
        public int DefensePoints { get; } = 0;
    }
}