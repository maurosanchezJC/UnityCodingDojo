using System;
using System.Collections.Generic;

namespace CodingDojo5
{
    public class Player
    {
        private List<string> chatHistory = new List<string>();
        private State currentState;
        
        public enum State
        {
            Alive,
            Defeated
        }

        public Player(string name, int maxLife)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Your player should have a Name!");
            }
            
            if (maxLife <= 0)
            {
                throw new Exception("Your player should have life points!");
            }
            
            Name = name;
            MaxLifePoints = maxLife;
        }

        public string Name { get; }
        private int MaxLifePoints { get; }
        
        public int LifePoints { get; private set; }
        
        public bool IsAlive => currentState == State.Alive;

        public string LastMessage => chatHistory[chatHistory.Count - 1];

        public void Heal(int points)
        {
            if (!IsAlive)
            {
                return;
            }
            
            LifePoints += points;
            if (LifePoints > MaxLifePoints)
            {
                LifePoints = MaxLifePoints;
            }
        }
        
        public void AddDamage(int points)
        {
            if (!IsAlive)
            {
                return;
            }
            
            LifePoints -= points;

            if (LifePoints <= 0)
            {
                Kill();
            }
        }

        public void Revive()
        {
            if (IsAlive)
            {
                throw new Exception("Player is already alive!");
            }

            LifePoints = MaxLifePoints;
            currentState = State.Alive;
        }

        public void Kill()
        {
            LifePoints = 0;
            currentState = State.Defeated;
        }

        public void Talk(string toSay)
        {
            if (string.IsNullOrEmpty(toSay))
            {
                throw new Exception("You should say something if you want to talk!");
            }

            if (!IsAlive)
            {
                throw new Exception("Dead people can't talk!");
            }
            
            Console.WriteLine($"{Name}: {toSay}");
            chatHistory.Add(toSay);
        }
    }
}