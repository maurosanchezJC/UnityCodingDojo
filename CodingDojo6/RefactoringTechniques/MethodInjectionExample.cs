namespace CodingDojo6
{
    public class MethodInjectionExample
    {
        public void Main()
        {
            //DEPENDENCY INJECTION BY METHOD
            MyTestableMemoryCard card = new MyTestableMemoryCard();
            SaveSystemByMethod constructor = new SaveSystemByMethod();
            constructor.Save(card);
        }
    }

    public class SaveSystemByMethod
    {
        public void Save(IMemoryCard card)
        {
            card.Save();
        }
    }
}