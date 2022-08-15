namespace ConsoleApplication1
{
    public class Example03
    {
        public void MyMethodForStructs<T>() where T : struct { }
        public void MyMethodForClasses<T>() where T : class { }
        public void MyMethodForInterfaces<T>() where T : IOtherRandomInterface { }
        public void MyMethodForConcretions<T>() where T : AbstractCharacter { }
        public void MyMethodForCreation<T>() where T : new() { }

        //This method contains multiple constrains.
        public void MyMethodWithVariousConstrains<T>() where T : class, IOtherRandomInterface, new() { }

        //This method contains multiple constrains of specific types (interfaces and classes)
        public void MyMethodWithVariousInheritances<T>() where T : AbstractCharacter, IOtherRandomInterface, new() {}
    }
}