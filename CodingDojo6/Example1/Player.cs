using System;
using System.Collections.Generic;
using System.Data;

namespace CodingDojo6
{
    public class Player
    {
        public string name;
        public int lifePoints = 10;
        public int attackPoints = 10; 
        public int defensePoints = 10;

        public Player() {}
        
        public Player(Dictionary<string, object> data)
        {
            name = (string)data["name"];
            lifePoints = (int)data["lifePoints"];
            attackPoints = (int)data["attackPoints"];
            defensePoints = (int)data["defensePoints"];
        }

        public Dictionary<string, object> GetRawData()
        {
            return new Dictionary<string, object>()
            {
                { "name", name },
                { "lifePoints", lifePoints },
                { "attackPoints", attackPoints },
                { "defensePoints", defensePoints },
            };
        }
    }
}