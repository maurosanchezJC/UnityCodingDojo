using System;

namespace KataOne.Properties
{
    public class HealingCalculator
    {
        public float CalculateHealingPoints(params Item[] items)
        {
            float total = 0;
            foreach (Item item in items)
            {
                if (item is MagicFlowers flower)
                {
                    switch (flower.FlowerColor)
                    {
                        case "red":
                            total += 200;
                            break;
                        case "yellow":
                            total += 10;
                            break;
                        case "green":
                            total += 999;
                            break;
                        default:
                            total += 1;
                            break;
                    }
                }
                else if (item is Meat meat)
                {
                    var random = new Random();
                    total += 100 + random.Next() * 0.2f;
                }
                else if (item is Potion potion)
                {
                    total += 300;
                }
            }

            return total;
        }
    }
}