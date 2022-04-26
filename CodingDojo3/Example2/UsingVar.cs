using System;
using System.Collections.Generic;

namespace CodingDojo3.Example3
{
    public class UsingVar
    {
        public void DoSomething()
        {
            var somethingA = GetSomethingComplex();
            var somethingB = GetSomethingSimple();
            var somethingC = GetAnotherThing();
            
            somethingB.ThisDoesSomething();
            Console.WriteLine(somethingC.ToString());
        }

        private int GetAnotherThing() => 3;
        
        public Dictionary<string, Dictionary<string, List<HashSet<Stack<int>>>>> GetSomethingComplex()
        {
            return new Dictionary<string, Dictionary<string, List<HashSet<Stack<int>>>>>();
        }

        public SomethingSimple GetSomethingSimple()
        {
            return new SomethingSimple();
        }

        public struct SomethingSimple
        {
            public void ThisDoesSomething()
            {
                Console.WriteLine("Something simple");
            }
        }
    }
}