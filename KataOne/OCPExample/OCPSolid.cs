using System;

namespace KataOne.OCPExample
{
    public class StatsCalculatorHandler
    {
        public void CalculateEquipmentWithSolid()
        {
            SolidArmor armor = new SolidArmor("nike");
            SolidBots bots = new SolidBots(false);
            SolidShield shield = new SolidShield();
            SolidSword sword = new SolidSword("long");
            SolidHelmet helmet = new SolidHelmet(true);

            SolidStatsCalculator statsCalculator = new SolidStatsCalculator();

            StatsData statsResult = statsCalculator.CalculateStates(armor, bots, shield, sword, helmet);

            Console.WriteLine(statsResult);
        }
    }

    public class SolidStatsCalculator
    {
        public StatsData CalculateStates(params IEquipment[] inventoryItems)
        {
            int totalAttack = 0;
            int totalDefense = 0;
            foreach (IEquipment equipment in inventoryItems)
            {
                totalAttack += equipment.AttackPoints;
                totalDefense += equipment.DefensePoints;
            }

            return new StatsData(totalAttack, totalDefense);
        }
    }

    public struct StatsData : IEquipment
    {
        public StatsData(int attackPoints, int defensePoints)
        {
            AttackPoints = attackPoints;
            DefensePoints = defensePoints;
        }

        public int AttackPoints { get; }
        public int DefensePoints { get; }


        public override string ToString()
        {
            return $"Attack: {AttackPoints} | Defense: {DefensePoints}";

        }
    }

    public interface IEquipment
    {
        int AttackPoints { get; }
        int DefensePoints { get; }
    }

    public class SolidHelmet : IEquipment
    {
        private const int HORNED_ATTACK = 10;
        private const int DEFAULT_DEFENSE = 10;

        private bool isHorned = false;

        public SolidHelmet(bool isHorned)
        {
            this.isHorned = isHorned;
        }

        public int AttackPoints => isHorned ? HORNED_ATTACK : 0;
        public int DefensePoints => DEFAULT_DEFENSE;
    }

    public class SolidSword : IEquipment
    {
        private const int DEFAULT_ATTACK = 10;
        private const int DEFAULT_DEFENSE = 0;

        public string swordType;

        public SolidSword(string swordType)
        {
            this.swordType = swordType;
        }

        public int AttackPoints
        {
            get
            {
                switch (swordType)
                {
                    case "short":
                        return DEFAULT_ATTACK - 3;
                    case "long":
                        return DEFAULT_ATTACK + 5;
                    case "dual":
                        return DEFAULT_ATTACK + 10;
                    default:
                        return DEFAULT_ATTACK;
                }
            }
        }

        public int DefensePoints => DEFAULT_DEFENSE;
    }

    public class SolidShield : IEquipment
    {
        private const int DEFAULT_ATTACK = 3;
        private const int DEFAULT_DEFENSE = 20;
        public int AttackPoints => DEFAULT_ATTACK;
        public int DefensePoints => DEFAULT_DEFENSE;
    }

    public class SolidBots : IEquipment
    {
        private const int DEFAULT_ATTACK = 2;
        private const int DEFAULT_DEFENSE = 2;

        public SolidBots(bool areCrocs)
        {
            this.areCrocs = areCrocs;
        }

        public bool areCrocs = false;
        public int AttackPoints => areCrocs ? 0 : DEFAULT_ATTACK;
        public int DefensePoints => areCrocs ? 0 : DEFAULT_DEFENSE;
    }

    public class SolidArmor : IEquipment
    {
        private const int DEFAULT_ATTACK = 0;
        private const int DEFAULT_DEFENSE = 10;

        public SolidArmor(string label)
        {
            this.label = label;
        }

        public string label;

        public int DefensePoints
        {
            get
            {
                switch (label)
                {
                    case "nike":
                        return DEFAULT_DEFENSE * 2;
                    case "adidas":
                        return DEFAULT_DEFENSE * 3;
                    default:
                        return DEFAULT_DEFENSE;
                }
            }
        }

        public int AttackPoints => label == "nike" ? 10 : DEFAULT_ATTACK;
    }
}