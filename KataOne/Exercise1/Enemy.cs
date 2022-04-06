using System;

namespace KataOne
{
    public class Enemy
    {
        private int health;
        private string name;
        private int attackPoints;

        public Enemy(string name, int health, int attackPoints)
        {
            this.health = health;
            this.name = name;
            this.attackPoints = attackPoints;
        }

        public void OnAttacked(int damage)
        {
            health -= damage;

            if (health == 0)
            {
                Console.WriteLine($"{name} is dead!");
                var random = new Random(100);
                if (random.Next() > 10)
                {
                    Console.WriteLine("The enemy drop a lot of argentinian pesos! grab them before they devaluate!");
                }
            }
            else
            {
                Console.WriteLine($"{name} was attacked!");
            }
        }
    }
}