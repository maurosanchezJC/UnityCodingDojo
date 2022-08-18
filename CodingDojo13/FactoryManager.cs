using System;
using System.Collections.Generic;

namespace CodingDojo13
{
    public class FactoryManager
    {
        // We can't create this type because we don't know which type the generic factory will be
        // private Dictionary<Type, GenericFactory<???>> genericFactories = new Dictionary<Type, GenericFactory<???>)();
        
        // So we create a collection but catching the object by ITS INTERFACE so we it matches with the collection.
        private Dictionary<Type, IFactory> factoryInstances = new Dictionary<Type, IFactory>();

        public GenericFactory<T> GetFactory<T>() where T : class, new()
        {
            Type factoryType = typeof(T);
            
            //if the factory already exists, we return that instead of creating another.
            if (factoryInstances.ContainsKey(factoryType))
            {
                //Here being that the instance already exists, we return it, but first we need to parse it to a
                // GenericFactory<T> because the object is saved as an IFactory object, not as a concrete class!
                return factoryInstances[factoryType] as GenericFactory<T>;
            }

            GenericFactory<T> newInstance = new GenericFactory<T>();
            //Here we can add the instance to the collection because it implicitly converts to an IFactory object.
            factoryInstances.Add(factoryType, newInstance);

            return newInstance;
        }
    }
    
    
    public class GenericFactory<T> : IFactory where T : class, new()
    {
        public T CreateObject() => new T();
    }
    
    
    // This factory allows us to categorize the Factories and catch them in collections. (Of course we can expand it)
    public interface IFactory {}
}