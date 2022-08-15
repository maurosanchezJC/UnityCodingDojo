using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CharacterHomer homer = new CharacterHomer();
            CharacterKrillin krillin = new CharacterKrillin();
            CharacterDami dami = new CharacterDami();
            
            //This method create the instance of the type that receives
            SayCharacterLineWithGenerics<CharacterHomer>();
            SayCharacterLineWithGenerics<CharacterKrillin>();
            SayCharacterLineWithGenerics<CharacterDami>();
            
            //These ones has the same input, one through interface and another through generics
            SayCharacterLineWithInterface(homer);
            SayCharacterLineWithInterface(krillin);
            SayCharacterLineWithInterface(dami);
            
            SayCharacterLineWithGenerics(homer);
            SayCharacterLineWithGenerics(krillin);
            SayCharacterLineWithGenerics(dami);
            
            SayCharacterLineWithGenerics<CharacterKrillin>();
            SayCharacterLineWithGenerics<CharacterDami>();
            
            //This method has a more explicit inheritance condition for the type that it receives
            // SayCharacterLineWithMultipleGenerics<CharacterDami>(); -> This won't work because Dami doesn't have a random interface
            SayCharacterLineWithMultipleGenerics<CharacterWithBothInterfaces>();
        }


        public static void SayCharacterLineWithGenerics<T>() where T : AbstractCharacter, new()
        {
            T instance = new T();
            instance.SayLine();
        }
        
        public static void SayCharacterLineWithMultipleGenerics<T>() where T : AbstractCharacter, IOtherRandomInterface, new()
        {
            T instance = new T();
            instance.SayLine();
        }
        
        public static void SayCharacterLineWithGenerics<T>(T obj) where T : AbstractCharacter, new()
        {
            obj.SayLine();
        }
        
        public static void SayCharacterLineWithInterface(AbstractCharacter character)
        {
            character.SayLine();
        }
    }

    public class CharacterKrillin : AbstractCharacter
    {
        public override string CharacterLine => "GOKUUU AAAAAH!";
    }
    
    public class CharacterHomer : AbstractCharacter
    {
        public override string CharacterLine => "A la grande le puse cuca";
    }

    public class CharacterWithBothInterfaces : AbstractCharacter, IOtherRandomInterface
    {
        public override string CharacterLine => "This is a character object with other random interface";
    }
    
    public class CharacterDami : AbstractCharacter
    {
        public override string CharacterLine => "VOS SOS UN TIPAZO!!!";
    }

    public interface IOtherRandomInterface
    {
        
    }

    public abstract class AbstractCharacter
    {
        public abstract string CharacterLine { get; }

        public void SayLine() => Console.WriteLine(CharacterLine);
    }
}