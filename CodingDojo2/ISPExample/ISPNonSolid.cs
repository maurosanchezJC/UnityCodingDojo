using System;

namespace UnityCodingDojo.ISPExample
{
    public class ISPNonSolid
    {
        public interface ICard
        {
            void Attack();
            void Defend();
            void Effect();
        }

        public class Card : ICard
        {
            public void Attack()
            {
                Console.Write("Attacking!");
            }

            public void Defend()
            {
                Console.Write("Defending!");
            }

            public void Effect() { }
        }

        public class ShieldCard : ICard
        {
            public void Attack() { }

            public void Defend()
            {
                Console.Write("Defending!");
            }

            public void Effect() { }
        }
        
        public class EffectCard : ICard
        {
            public void Attack() { }

            public void Defend() { }

            public void Effect()
            {
                Console.WriteLine("Effect triggered!");
            }
        }
    }
}