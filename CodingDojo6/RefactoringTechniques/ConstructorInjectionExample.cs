using System;

namespace CodingDojo6
{
    public class ConstructorInjectionExample
    {
        public void Main()
        {
            // DEPENDENCY INJECTION BY CONSTRUCTOR
            IMemoryCard memoryCardForConstructor = new MyMemoryCard();
            SaveSystemByConstructor saveSystemByConstructor = 
                new SaveSystemByConstructor(memoryCardForConstructor);
        }
    }

    public class SaveSystemByConstructor
    {
        private IMemoryCard memoryCard;

        public SaveSystemByConstructor(IMemoryCard memoryCard)
        {
            this.memoryCard = memoryCard;
        }
    }

    public class MyMemoryCard : IMemoryCard
    {
        public void Save()
        {
            Console.WriteLine("Memory Card save");
        }
    }

    public class MyTestableMemoryCard : IMemoryCard
    {
        public void Save()
        {
            Console.WriteLine("Testing Memory card Save");
        }
    }

    public interface IMemoryCard
    {
        void Save();
    }
}