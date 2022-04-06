using System;
using System.Collections.Generic;

namespace KataOne
{
    public class Player
    {
        private int health;
        private int attackPoints;
        private string name;
        private Dictionary<string, int> inventory = new Dictionary<string, int>();
        private int currentStateIndex = 0;

        private string[] states = new[]
        {
            "idle",
            "attacking",
            "damaged",
            "dead"
        };

        public Player(string name, int health, int attackPoints)
        {
            this.attackPoints = attackPoints;
            this.health = health;
            this.name = name;
        }

        public void AddDamage(int amount)
        {
            health -= amount;
            currentStateIndex = 2;

            if (health < 0)
            {
                currentStateIndex = 3;
            }
            
            ChangeState();
            Console.WriteLine($"{name} received {amount} of damage! {name} health is {health}");
        }

        public void ChangeState()
        {
            Console.WriteLine($"{name} is {states[currentStateIndex]}");
        }

        public void Die()
        {
            Console.WriteLine($"{name} is dead!");
        }

        public void AddItemToInventory(string itemName, int quantity = 1)
        {
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory.Add(itemName, quantity);
            }
        }

        public int GetItemAmount(string itemName)
        {
            int amount;
            if (inventory.ContainsKey(itemName))
            {
                amount = inventory[itemName];
            }
            else
            {
                amount = 0;
            }

            return amount;
        }

        public void Attack(object objectToAttack)
        {
            if (objectToAttack is Enemy)
            {
                currentStateIndex = 1;
                ChangeState();
                (objectToAttack as Enemy).OnAttacked(attackPoints);
            }
            else if (objectToAttack is Prop)
            {
                currentStateIndex = 1;
                ChangeState();
                var prop = (Prop)objectToAttack;
                prop.OnAttacked(attackPoints);
            }
        }
        
    }
}