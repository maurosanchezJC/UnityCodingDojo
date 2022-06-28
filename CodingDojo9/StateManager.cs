using System.Collections.Generic;

namespace CodingDojo9
{
    public class StateManager : IStateManager
    {
        public string Identifier { get; set; }
        
        private Dictionary<string, object> state;

        public void Initialize(string identifier)
        {
            Identifier = identifier;
            state = new Dictionary<string, object>();
        }

        public T GetValue<T>(string key)
        {
            if (!state.ContainsKey(key))
            {
                return default(T);
            }

            return (T)state[key];
        }

        public void SetValue<T>(string key, T value)
        {
            state[key] = value;
        }

        public void SubmitState()
        {
            Dictionary<string, object> toSubmit = new Dictionary<string, object>();
            toSubmit[Identifier] = state;
            
            //We save the object in a file or send this to the server.
        }
    }
}