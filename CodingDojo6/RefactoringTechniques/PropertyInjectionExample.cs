namespace CodingDojo6
{
    public class PropertyInjectionExample
    {
        public void Main()
        {
            // DEPENDENCY INJECTION BY PROPERTY
            IMemoryCard memoryCardForProperty = new MyMemoryCard();
            SaveSystemByProperty saveSystemByProperty = new SaveSystemByProperty();
            saveSystemByProperty.MemoryCard = memoryCardForProperty;
        }
    }
    
    public class SaveSystemByProperty
    {
        public IMemoryCard MemoryCard { get; set; }
    }
}