namespace UnityCodingDojo.Dojo1.Exercise2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Exercise:
            // - Refactor the structures used on this game to be SOLID compliant.
            // - Add at least 2 more of the following:
            // - - Heroes
            // - - Abilities
            // - - Spells

            GameHandler gameHandler = new GameHandler();

            WarriorHero warrior = new WarriorHero();
            warrior.Name = "Player 1";
            
            MageHero mage = new MageHero();
            mage.Name = "Player 2";

            PoisonTerrain terrain = new PoisonTerrain();
            
            gameHandler.StartGame(warrior, mage, terrain);
        }
    }
}