namespace CodingDojo3.Example3
{
    public class UnnecessaryFeature
    {
        public void AttackWithAWarrior()
        {
            Warrior warriorA = new Warrior();
            Warrior warriorB = new Warrior();
            
            warriorA.Attack(warriorB);
        }
        
        public class Warrior : IAttackTarget, IHealTarget
        {
            private int attackPoints = 30;
            private int lifePoints = 50;
            private string name = "warrior";

            public void Attack(IAttackTarget target)
            {
                target.ApplyDamage(attackPoints);
            }

            //Warriors don't heal. This shouldn't be a feature.
            public void Heal(IHealTarget target)
            {
                target.Heal(attackPoints);
            }

            public void ApplyDamage(int damage)
            {
                lifePoints -= damage;
            }

            public void Heal(int lifePoints)
            {
                this.lifePoints -= lifePoints;
            }
        }
        
        public interface IAttackTarget
        {
            void ApplyDamage(int damage);
        }
        public interface IHealTarget
        {
            void Heal(int lifePoints);
        }
    }
}