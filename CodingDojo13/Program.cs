namespace CodingDojo13
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Shoe shoe = new Shoe();
            Shirt shirt = new Shirt();
            Ether ether = new Ether();
            
            Box<Shoe> shoeBox = new Box<Shoe>();
            shoeBox.Add(shoe);
            // shoeBox.Add(shirt); This won't compile because shirt is not a shoe!

            Box<IConcreteObject> boxOfThings = new Box<IConcreteObject>();
            boxOfThings.Add(shoe);
            boxOfThings.Add(shirt); //This compiles because the box is done of things in general
            // boxOfThings.Add(ether); /This won't compile because ether is not a concrete object, is a quantum object!

        }
    }

    public class Shoe : IConcreteObject
    {
            
    }

    public class Shirt : IConcreteObject
    {
            
    }

    public class Ether : IQuantumObject
    {
            
    }
}