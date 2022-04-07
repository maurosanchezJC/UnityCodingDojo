using System;

namespace UnityCodingDojo.OCPExample
{
    public class NonSolidStatsCalculatorHandler
    {
        public void CalculateEquipmentWithSolid()
        {
            Armor armor = new Armor("nike");
            Bots bots = new Bots(false);
            Shield shield = new Shield();
            Sword sword = new Sword("long");
            Helmet helmet = new Helmet(true);

            StatsCalculator statsCalculator = new StatsCalculator();

            (int, int) statsResult = statsCalculator.CalculateStates(armor, bots, shield, sword, helmet);

            Console.WriteLine($"Attack: {statsResult.Item1} | Defense: {statsResult.Item2}");
        }
    }
    
    public class StatsCalculator
    {
        public (int, int) CalculateStates(params object[] inventoryItems)
        {
            (int, int) stats = (0, 0);
            foreach (var item in inventoryItems)
            {
                if (item is Helmet helmet)
                {
                    stats.Item1 += helmet.isHorned ? helmet.attack + 3 : helmet.attack;
                    stats.Item2 += helmet.def;
                }
                else if (item is Sword sword)
                {
                    stats.Item1 += sword.attack;
                    stats.Item2 += sword.def;

                    switch (sword.swordType)
                    {
                        case "long":
                            stats.Item1 += 5;
                            break;
                        case "short":
                            stats.Item1 -= 3;
                            break;
                        case "dual":
                            stats.Item1 += 10;
                            break;
                    }
                }
                else if (item is Shield shield)
                {
                    Random random = new Random();
                    stats.Item1 += shield.attack;
                    stats.Item2 += shield.def + random.Next() * 2;
                }
                else if (item is Bots bots)
                {
                    if (bots.areCrocs)
                    {
                        stats.Item1 += 0;
                        stats.Item2 += 0;
                    }
                    else
                    {
                        stats.Item1 += bots.attack;
                        stats.Item2 += bots.def;
                    }
                }
                else if (item is Armor armor)
                {

                    if (armor.label == "adidas")
                    {
                        stats.Item2 += armor.defense * 3;
                    }
                    else if (armor.label == "nike")
                    {
                        stats.Item1 += 10;
                        stats.Item2 += armor.defense * 2;
                    }
                    else
                    {
                        stats.Item2 += armor.defense;
                    }
                }
            }

            return stats;
        }
    }

    public class Helmet
    {
        public Helmet(bool isHorned)
        {
            this.isHorned = isHorned;
        }

        public bool isHorned = false;
        public int attack = 0;
        public int def = 10;
    }

    public class Sword
    {
        public Sword(string swordType)
        {
            this.swordType = swordType;
        }

        public string swordType;
        public int attack = 10;
        public int def = 0;
    }

    public class Shield
    {
        public int attack = 3;
        public int def = 20;
    }

    public class Bots
    {
        public Bots(bool areCrocs)
        {
            this.areCrocs = areCrocs;
        }

        public bool areCrocs = false;
        public int attack = 1;
        public int def = 1;
    }

    public class Armor
    {
        public Armor(string label)
        {
            this.label = label;
        }

        public string label;
        public int attack = 0;
        public int defense = 10;
    }
}