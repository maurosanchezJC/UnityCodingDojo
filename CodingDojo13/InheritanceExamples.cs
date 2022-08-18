namespace CodingDojo13
{
    //This interface contains 2 generic definitions on its types
    public interface IGenericInterface<T1, T2> where T1 : class, new() where T2 : class, new()
    {
        T1 ReturnAnInstanceOfOne();
        T2 ReturnAnInstanceOfTwo();
    }

    //This class inherits from the previous interface, so it should define the generic types that it will create
    public class GenericConcreteInheritance : IGenericInterface<GenericDependency1, GenericDependency2>
    {
        public GenericDependency1 ReturnAnInstanceOfOne() => new GenericDependency1();

        public GenericDependency2 ReturnAnInstanceOfTwo() => new GenericDependency2();
    }
    
    // This inheritance is ALSO GENERIC and the same types are being sent to the interface.
    // Also check that the inheritance conditions MATCHES with the ones requested by the interface!
    public class GenericConcreteInheritance<T1, T2> : IGenericInterface<T1, T2> where T1 : class, new() where T2 : class, new()
    {
        public T1 ReturnAnInstanceOfOne() => new T1();

        public T2 ReturnAnInstanceOfTwo() => new T2();
    }
    
    public class GenericDependency1 {}
    public class GenericDependency2 {}
}