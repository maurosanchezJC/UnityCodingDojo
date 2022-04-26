using System;
using System.Collections.Generic;

namespace CodingDojo3
{
    public class PlayerPrinter
    {
        public void Print()
        {
            Console.WriteLine($"There are {RemainingPlayerLevels.Count} players alive. They are:");
            
            foreach (KeyValuePair<string, int> remainingPlayer in RemainingPlayerLevels)
            {
                Console.WriteLine($"Player: {remainingPlayer.Key} || Level: {remainingPlayer.Value}");
            }
        }
        private List<PlayerData> allPlayers = new List<PlayerData>
        {
            new PlayerData("Mati", 10, "warrior", 200),
            new PlayerData("Dami", 999, "tipazo", 3),
            new PlayerData("Mau", 1, "warrior", 0),
            new PlayerData("Kratos", 200, "warrior", 10),
            new PlayerData("Mirta Legrand", int.MaxValue, "necromancer", 0),
            new PlayerData("Kratos", 30, "warrior", 30),
        };

        private List<string> warriorNames = new List<string>();

        private Dictionary<string, int> RemainingPlayerLevels
        {
            get
            {
                if (warriorNames == null)
                {
                    warriorNames = new List<string>();
                    foreach (var player in allPlayers)
                    {
                        if (player.charClass == "warrior")
                        {
                            warriorNames.Add(player.name);
                        }
                    }
                }

                Dictionary<string, int> toReturn = new Dictionary<string, int>();
                foreach (var warriorName in warriorNames)
                {
                    foreach (var player in allPlayers)
                    {
                        if (player.playerLife > 0)
                        {
                            toReturn.Add(warriorName, player.level);
                        }
                    }
                }

                return toReturn;
            }
        }
        
        
        private Dictionary<string, int> RemainingPlayerHealth
        {
            get
            {
                if (warriorNames == null)
                {
                    warriorNames = new List<string>();
                    foreach (var player in allPlayers)
                    {
                        if (player.charClass == "warrior")
                        {
                            warriorNames.Add(player.name);
                        }
                    }
                }

                Dictionary<string, int> toReturn = new Dictionary<string, int>();
                foreach (var warriorName in warriorNames)
                {
                    foreach (var player in allPlayers)
                    {
                        if (player.playerLife > 0)
                        {
                            toReturn.Add(warriorName, player.playerLife);
                        }
                    }
                }

                return toReturn;
            }
        }

        public class PlayerData
        {
            public string name;
            public int level;
            public string charClass;
            public int playerLife;

            public PlayerData(string name, int level, string charClass, int playerLife)
            {
                this.name = name;
                this.level = level;
                this.charClass = charClass;
                this.playerLife = playerLife;
            }

            public override string ToString()
            {
                return $"{name} || Level: {level} || Class: {charClass} || Life: {playerLife}";
            }
        }
    }
}