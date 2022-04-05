using System;

namespace KataOne.ISPExample
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

            public void Effect()
            {
                throw new Exception("Card doesnt have an effect");
            }
        }

        public class ShieldCard : ICard
        {
            public void Attack()
            {
                throw new Exception("Card doesnt attack");
            }

            public void Defend()
            {
                Console.Write("Defending!");
            }

            public void Effect()
            {
                throw new Exception("Card doesnt have an effect");
            }
        }
        
        public class EffectCard : ICard
        {
            public void Attack()
            {
                throw new Exception("Card doesnt attack");
            }

            public void Defend()
            {
                throw new Exception("Card doesnt defend");
            }

            public void Effect()
            {
                Console.WriteLine("Effect triggered!");
            }
        }
    }
}