namespace UnityCodingDojo.Dojo1.Exercise2
{

    public abstract class AbstractHero
    {
        public string Name { get; set; }
        public abstract int LifePoints { get; set; }
        public abstract int AttackPoints { get; set; }
        public abstract int DefensePoints { get; set; }
        public abstract int ManaPoints { get; set; }

        public abstract AbstractAbility DefaultAbility { get; }
        
        public abstract AbstractAbility[] Abilities { get; }
    }

    public class WarriorHero : AbstractHero
    {
        public override int LifePoints { get; set; } = 2500;
        public override int AttackPoints { get; set; } = 200;
        public override int DefensePoints { get; set; } = 10;
        public override int ManaPoints { get; set; }
        public override AbstractAbility DefaultAbility => new Attack();
        public override AbstractAbility[] Abilities => new AbstractAbility[]
        {
            new PowerUp()
        };
    }
    
    public class MageHero : AbstractHero
    {
        public override int LifePoints { get; set; } = 4000;
        public override int AttackPoints { get; set; } = 100;
        public override int DefensePoints { get; set; } = 70;
        public override int ManaPoints { get; set; }
        public override AbstractAbility DefaultAbility => new FireAttack();
        public override AbstractAbility[] Abilities { get; }
    }
}