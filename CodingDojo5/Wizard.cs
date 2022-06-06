namespace CodingDojo5
{
    public class Wizard
    {
        public int ManaPoints { get; set; }

        public bool CanCastMagic(int magicCost) => ManaPoints >= magicCost;
    }
}