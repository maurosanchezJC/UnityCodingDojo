using System.Collections.Generic;
using ComplexClass = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.HashSet<System.Collections.Generic.Stack<int>>>>>;


namespace CodingDojo3.Example3
{
    public class UsingComplexVariables
    {
        
        public void DoSomething()
        {
            //Getting objects
            Dictionary<string, Dictionary<string, List<HashSet<Stack<int>>>>> somethingA = GetSomethingComplex();
            ComplexClass somethingB = GetSomethingSimplified();
            
            //Getting something complex on both
            Dictionary<string, Dictionary<string, List<HashSet<Stack<int>>>>> somethingC = GetSomethingComplex();
            ComplexClass somethingD = GetSomethingComplex();
            
            //Getting something simplified on both
            Dictionary<string, Dictionary<string, List<HashSet<Stack<int>>>>> somethingE = GetSomethingSimplified();
            ComplexClass somethingF = GetSomethingSimplified();
        }
        
        public Dictionary<string, Dictionary<string, List<HashSet<Stack<int>>>>> GetSomethingComplex()
        {
            return new Dictionary<string, Dictionary<string, List<HashSet<Stack<int>>>>>();
        }
        
        public ComplexClass GetSomethingSimplified()
        {
            return new ComplexClass();
        }
    }
}