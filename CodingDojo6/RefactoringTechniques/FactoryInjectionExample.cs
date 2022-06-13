using System;

namespace CodingDojo6
{
    public class FactoryInjectionExample
    {
        public void Main()
        {
            //DEPENDENCY INJECTION BY FACTORY
            //This Save System contains a reference to the Card Factory that retrieves the card that should use
            SaveSystemWithFactory saveSystemWithFactory = new SaveSystemWithFactory();
            
            //Now firstly we define the Memory Card type that will be applied on the Test and then create the save system
            MemoryCardFactory.SetCardType<MyTestableMemoryCard>();
            SaveSystemWithFactory testableSaveSystem = new SaveSystemWithFactory();

        }
    }

    public class SaveSystemWithFactory
    {
        private IMemoryCard memoryCardType;

        public SaveSystemWithFactory()
        {
            memoryCardType = MemoryCardFactory.GetNewCard();
        }
    }

    public static class MemoryCardFactory
    {
        private static Type memoryCardType = typeof(MyMemoryCard);

        public static IMemoryCard GetNewCard()
        {
            return (IMemoryCard) Activator.CreateInstance(memoryCardType);
        }

        public static void SetCardType<T>() where T : IMemoryCard
        {
            memoryCardType = typeof(T);
        }
    }
}