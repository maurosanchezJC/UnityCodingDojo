using System;

namespace UnityCodingDojo.Dojo1.Exercise1
{
    public class MagicFlowers : Item
    {
        private string flowerColor;
        
        public MagicFlowers(string flowerColor)
        {
            this.flowerColor = flowerColor;
        }

        public string FlowerColor
        {
            get => flowerColor;
            set => flowerColor = value;
        }

        public void ShowColor() => Console.WriteLine($"This flower is {flowerColor}");
    }
}