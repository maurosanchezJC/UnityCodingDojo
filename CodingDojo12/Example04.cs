namespace ConsoleApplication1
{
    public class Example04
    {
        //This method needs 3 generic types to operate.
        public static void MethodWithMultipleGenerics<T1, T2, T3>() where T1 : AbstractCharacter where T2 : IOtherRandomInterface where T3 : new()
        {
            //This does something.
        }
    }
}