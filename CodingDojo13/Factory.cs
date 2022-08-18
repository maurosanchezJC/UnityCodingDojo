namespace CodingDojo13
{
    public class FactoryExamples
    {
        public void Main()
        {
            //These two objects are basically the same, but the ShoeFactory is a wrapper that can expand the factory.
            ShoeFactory shoeFactoryByInheritance = new ShoeFactory();
            Factory<Shoe> shoeFactoryByGeneric = new Factory<Shoe>();
            
            ShirtFactory shirtFactory = new ShirtFactory();
            EtherFactory etherFactory = new EtherFactory();

            //All the classes calls the same generic method but retrieve a different object, the one declared by the generic.
            Ether newEther = etherFactory.CreateObject();
            Shirt newShirt = shirtFactory.CreateObject();
            Shoe leftShoe = shoeFactoryByGeneric.CreateObject();
            Shoe rightShoe = shoeFactoryByInheritance.CreateObject();
        }
    }
    
    public class Factory<T>  where T : class, new()
    {
        public T CreateObject() => new T();
    }

    public class ShoeFactory : Factory<Shoe> { }
    public class ShirtFactory : Factory<Shirt> { }
    public class EtherFactory : Factory<Ether> { }
}