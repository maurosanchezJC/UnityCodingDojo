using System;

namespace ConsoleApplication1
{
    public class Example02
    {
        public void Execute()
        {
            //The Generic type should match the inheritance constrains, if not, it won't compile 
            MyNewMethod<CharacterWithBothInterfaces>();
        }
        
        
        private void MyNewMethod<T>() where T : class, IOtherRandomInterface, new()
        {
            //This does somethings.
        }
    }
}