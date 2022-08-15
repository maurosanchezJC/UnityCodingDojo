using System;

namespace ConsoleApplication1
{
    public class Example01
    {
        public void Execute()
        {
            CharacterWithBothInterfaces character = new CharacterWithBothInterfaces();
            
            //All these methods do the same defined in a different way.
            PrintObject(character as object);
            PrintObject(character as IOtherRandomInterface);
            PrintObject<CharacterWithBothInterfaces>(character);
            PrintObject(character);
        }


        private void PrintObject(object obj)
        {
            Console.WriteLine(obj);
        }

        private void PrintObject<T>(T obj)
        {
            Console.WriteLine(obj);
        }

        private void PrintObject(IOtherRandomInterface obj)
        {
            Console.WriteLine(obj);
        }
    }
    

}