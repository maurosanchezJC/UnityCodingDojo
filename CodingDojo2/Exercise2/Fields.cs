namespace UnityCodingDojo.Dojo1.Exercise2
{
    public class GrasslandTerrain
    {
        public void ApplyStartingEffect(AbstractHero playerOne, AbstractHero playerTwo)
        {
            if (playerOne is WarriorHero)
            {
                playerOne.AttackPoints = (int)(playerOne.AttackPoints * 1.2f);
            }
            
            if (playerTwo is WarriorHero)
            {
                playerOne.AttackPoints = (int)(playerOne.AttackPoints * 1.2f);
            }
        }

        public void ApplyTurnEffect(AbstractHero playerOne, AbstractHero playerTwo)
        {
        }
    }

    public class PoisonTerrain
    {
        public void ApplyStartingEffect(AbstractHero playerOne, AbstractHero playerTwo)
        {
        }
        
        public void ApplyTurnEffect(AbstractHero playerOne, AbstractHero playerTwo)
        {
            playerOne.LifePoints -= (int)(playerOne.LifePoints * 0.05f);
            playerTwo.LifePoints -= (int)(playerTwo.LifePoints * 0.05f);
        }
    }
}