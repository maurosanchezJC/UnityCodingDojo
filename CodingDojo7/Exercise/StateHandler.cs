using System.Collections.Generic;

namespace CodingDojo7.Exercise
{
    public class StateHandler
    {
        private IMemoryCard memoryCard;
        private Dictionary<string, object> currentState = new Dictionary<string, object>();

        public StateHandler()
        {
            memoryCard = new BinaryMemoryCard();
        }

        public void AddRegistry(string key, object data)
        {
            currentState[key] = data;
        }

        public void RemoveRegistry(string key)
        {
            if (currentState.ContainsKey(key))
            {
                currentState.Remove(key);
            }
        }
        
        public void SaveState()
        {
            memoryCard.Save(currentState);
        }

        public void LoadState()
        {
            currentState = memoryCard.Load();
        }
    }
}