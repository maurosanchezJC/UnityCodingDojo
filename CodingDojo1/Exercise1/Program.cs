using System;

namespace UnityCodingDojo.Dojo1.Exercise1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Challenge: Apply the SRP, OCP and LSP Principles to the classes involved on the following program
            
            Player megaMau = new Player("megaMau", 99, 100);
            Enemy antiMau = new Enemy("antiMau", 10, 30);
            Prop cardboardBox = new Prop();
            
            megaMau.Attack(antiMau);
            megaMau.Attack(cardboardBox);

            var healingCalc = new HealingCalculator();
            Potion potion = new Potion();
            Meat meat = new Meat();
            MagicFlowers flowers = new MagicFlowers("green");

            float healingPoints = healingCalc.CalculateHealingPoints(potion, meat, flowers);
            Console.WriteLine($"with those items you will heal {healingPoints}");
        }
    }
}