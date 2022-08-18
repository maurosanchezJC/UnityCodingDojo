using System;

namespace CodingDojo13
{
    public class Box<T> where T : class, IConcreteObject
    {
        private int currentIndex = 0;

        private T[] registries;
        
        public Box(int boxSpace = 100)
        {
            registries = new T[boxSpace];
        }

        public void Add(T obj)
        {
            if (currentIndex >= registries.Length)
            {
                throw new Exception($"{GetType()} :: The box doesn't have enough space!");
            }
            
            registries[currentIndex] = obj;
            currentIndex++;
        }

        public T GetObject(int index)
        {
            if (index >= currentIndex || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return registries[index];
        }
    }

    public interface IConcreteObject
    {
        
    }
    
    public interface IQuantumObject
    {
        
    }
}