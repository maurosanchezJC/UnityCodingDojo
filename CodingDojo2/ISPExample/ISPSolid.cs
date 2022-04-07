using System;

namespace UnityCodingDojo.ISPExample
{
    public class ISPSolid
    {
        public interface IAttackCard
        {
            void Attack();
        }
        public interface IDefenseCard
        {
            void Defend();
        }
        public interface IEffectCard
        {
            void Effect();
        }

        public class Card : IAttackCard, IDefenseCard
        {
            public void Attack()
            {
                Console.Write("Attacking!");
            }

            public void Defend()
            {
                Console.Write("Defending!");
            }
        }

        public class ShieldCard : IDefenseCard
        {
            public void Defend()
            {
                Console.Write("Defending!");
            }
        }
        
        public class EffectCard : IEffectCard
        {
            public void Effect()
            {
                Console.WriteLine("Effect triggered!");
            }
        }
    }
}