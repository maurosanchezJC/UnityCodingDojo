using System;
using System.Collections.Generic;

namespace UnityCodingDojo.SRPExample
{
    public class CardPlayer
    {
        private List<string> deck = new List<string>();
        private List<string> cemetery = new List<string>();
            
        public void PlayCard(string cardName, string cardEffect)
        {
            if (!ContainsCard(cardName))
            {
                throw new Exception($"The card {cardName} is not on your deck!");
            }

            if (CardIsInCemetery(cardName))
            {
                throw new Exception($"The card {cardName} is already on the cemetery and can't be played!");
            }
                
            ExecuteCardBehavior(cardName, cardEffect);
        }

        private void ExecuteCardBehavior(string cardName, string effect)
        {
            Console.WriteLine($"The {cardName} will activate the effect: {effect}");
        }

        private void AddToCemetery(string cardName) => cemetery.Add(cardName);
            
        private bool ContainsCard(string cardName) => deck.Contains(cardName);
        private bool CardIsInCemetery(string cardName) => cemetery.Contains(cardName);
    }
}