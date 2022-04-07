using System;

namespace UnityCodingDojo.Dojo1.Exercise2
{
    public abstract class AbstractAbility
    {
        public abstract int AttackPoints { get; set; }
        public abstract int ManaCost { get; set; }
        public abstract void Execute(AbstractHero owner, AbstractHero target);
    }

    public class Attack : AbstractAbility
    {
        public override int AttackPoints { get; set; }
        public override int ManaCost { get; set; }
        public override void Execute(AbstractHero owner, AbstractHero target)
        {
            target.LifePoints -= owner.AttackPoints;
            Console.WriteLine($"{owner.Name} attacked with a sword!");
        }
    }
    
    public class FireAttack : AbstractAbility
    {
        public override int AttackPoints { get; set; }
        public override int ManaCost { get; set; }
        public override void Execute(AbstractHero owner, AbstractHero target)
        {
            if (owner.ManaPoints < ManaCost)
            {
                Console.WriteLine($"{owner.Name} doesn't have enough Mana to cast magic!");
                return;
            }
            
            target.LifePoints -= owner.AttackPoints;
            owner.ManaPoints -= ManaCost;
            Console.WriteLine($"{owner.Name} attacked with magic fire!");
        }
    }

    public class PowerUp : AbstractAbility
    {
        public override int AttackPoints { get; set; }
        public override int ManaCost { get; set; }
        public override void Execute(AbstractHero owner, AbstractHero target)
        {
            owner.AttackPoints += 2;
            Console.WriteLine($"{owner.Name} boosted its attack by 2! Attack Points: {owner.AttackPoints}");
        }
    }
    
}