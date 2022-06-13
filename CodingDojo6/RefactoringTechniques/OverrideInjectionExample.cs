namespace CodingDojo6
{
    public class OverrideInjectionExample
    {
        public void Main()
        {
            // DEPENDENCY INJECTION BY OVERRIDE

            //Original
            BaseSaveSystem baseSaveSystem = new BaseSaveSystem();

            //Testable
            TestableSaveSystem testableSaveSystem = new TestableSaveSystem();
            testableSaveSystem.MemoryCard = new MyTestableMemoryCard();
        }
    }
    
    public class BaseSaveSystem
    {
        protected IMemoryCard memoryCard;

        public BaseSaveSystem()
        {
            memoryCard = new MyMemoryCard();
        }

        public void Save()
        {
            GetMemoryCard().Save();
        }

        protected virtual IMemoryCard GetMemoryCard() => memoryCard;
    }

    public class TestableSaveSystem : BaseSaveSystem
    {
        public IMemoryCard MemoryCard
        {
            get => memoryCard;
            set => memoryCard = value;
        }
        
        //or
        protected override IMemoryCard GetMemoryCard() => new MyTestableMemoryCard();
    }
}