using System;
using System.Collections.Generic;

namespace KataOne.DIPExample
{
    public class DIPNonSolid
    {
        public void Implementation()
        {
            Dictionary<string, object> playerState = new Dictionary<string, object>();

            SaveSystem saveSystem = new SaveSystem();
            
            saveSystem.SaveGame(playerState);
        }
        
        private class SaveSystem
        {
            private MemoryCard _memoryCard;
            
            public SaveSystem()
            {
                _memoryCard = new MemoryCard();
            }

            public void SaveGame(object objToSave)
            {
                _memoryCard.Save(objToSave);
            }
        }

        private class MemoryCard
        {
            public void Save(object objToSerialize)
            {
                Console.WriteLine($"{GetType()} :: We are saving!");
            }
        }
    }
}