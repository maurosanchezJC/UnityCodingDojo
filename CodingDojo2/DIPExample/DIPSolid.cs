using System;
using System.Collections.Generic;

namespace UnityCodingDojo.DIPExample
{
    public class DIPSolid
    {
        public void Implementation()
        {
            Dictionary<string, object> playerState = new Dictionary<string, object>();

            IMemoryCard binaryCard = new BinaryMemoryCard();
            SaveSystem binarySystem = new SaveSystem(binaryCard);
            
            IMemoryCard prefCard = new PrefMemoryCard();
            SaveSystem prefSystem = new SaveSystem(prefCard);
            
            IMemoryCard jsonCard = new JsonMemoryCard();
            SaveSystem jsonSystem = new SaveSystem(jsonCard);
            
            binarySystem.SaveGame(playerState);
            prefSystem.SaveGame(playerState);
            jsonSystem.SaveGame(playerState);
        }
        
        private class SaveSystem
        {
            private IMemoryCard _memoryCard;
            
            public SaveSystem(IMemoryCard memoryCard)
            {
                _memoryCard = memoryCard;
            }

            public void SaveGame(object objToSave)
            {
                _memoryCard.Save(objToSave);
            }
        }
        
        private interface IMemoryCard
        {
            void Save(object objToSerialize);
        }

        private class BinaryMemoryCard : IMemoryCard
        {
            public void Save(object objToSerialize)
            {
                Console.WriteLine($"{GetType()} :: We are saving with a BinarySerializer!");
            }
        }
        
        private class JsonMemoryCard : IMemoryCard
        {
            public void Save(object objToSerialize)
            {
                Console.WriteLine($"{GetType()} :: We are saving into a JSON File!");
            }
        }
        
        private class PrefMemoryCard : IMemoryCard
        {
            public void Save(object objToSerialize)
            {
                Console.WriteLine($"{GetType()} :: We are saving into PlayerPrefs!");
            }
        }
    }
}