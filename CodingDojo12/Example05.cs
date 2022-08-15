namespace ConsoleApplication1.Properties
{
    public class Example05
    {
        //This method creates and returns a new instance of the type T.
        public static T CreateObject<T>() where T : class, new()
        {
            return new T();
        }
    }
}