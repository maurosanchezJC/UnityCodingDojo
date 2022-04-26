using System;
using System.Collections.Generic;

namespace CodingDojo3.Example3
{
    public class ComplexMethods
    {
        private Dictionary<string, object> userState;
        private List<string> heroClasses;
        
        public string GetPlayerHeroClass()
        {
            if (heroClasses == null)
            {
                heroClasses = new List<string>();
                heroClasses.Add("warrior");
                heroClasses.Add("mage");
                heroClasses.Add("barbarian");
                heroClasses.Add("tipazo");
                heroClasses.Add("programmer");
                heroClasses.Add("ovni");
                heroClasses.Add("penguin");
            }

            if (userState == null)
            {
                userState = GetPlayerState();
                if (userState == null)
                {
                    userState = new Dictionary<string, object>();
                }
            }

            if (userState.ContainsKey("heroClassIndex"))
            {
                int heroClassIndex = (int)userState["heroClassIndex"];
                if (heroClasses.Count < heroClassIndex)
                {
                    return heroClasses[heroClassIndex];
                }
                else
                {
                    return heroClasses[0];
                }
            }
            else
            {
                return heroClasses[0];
            }
            
            
        }

        private Dictionary<string, object> GetPlayerState()
        {
            //This method returns the user state
            return new Dictionary<string, object>();
        }
    }
    
    public class ExplicitMethods
    {
        private Dictionary<string, object> userState;
        private List<string> heroClasses;

        private List<string> GetHeroClasses()
        {
            if (heroClasses == null)
            {
                heroClasses = new List<string>
                {
                    "warrior",
                    "mage",
                    "barbarian",
                    "tipazo",
                    "programmer",
                    "ovni",
                    "penguin"
                };
            }
            
            return heroClasses;
        }
        
        public string GetPlayerHeroClass()
        {
            List<string> heroClasses = GetHeroClasses();
            Dictionary<string, object> playerState = GetOrCreatePlayerState();

            return GetStateHeroClass(playerState, heroClasses);
        }

        private string GetStateHeroClass(Dictionary<string, object> state, List<string> classes)
        {
            string heroClassKey = "heroClassIndex";
            if (!userState.ContainsKey(heroClassKey))
            {
                return classes[0];
            }
            else
            {
                return classes[(int)userState[heroClassKey]];
            }
        }
        
        
        private Dictionary<string, object> GetOrCreatePlayerState()
        {
            bool stateExists = false; //Lets imagine this method creates or load the state
            return stateExists ? GetPlayerState() : new Dictionary<string, object>();
        }

        private Dictionary<string, object> GetPlayerState()
        {
            //This method returns the user state
            return new Dictionary<string, object>();
        }
    }
}