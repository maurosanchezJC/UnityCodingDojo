using System;
using System.Collections.Generic;

namespace KataOne.SRPExample
{
    public class SolidCardPlayer
    {
        private PlayerDeck _playerDeck;
        private GraveyardDeck _playerGraveyard;
        private CardBehaviorHandler _behaviorhandler;

        public SolidCardPlayer(PlayerDeck playerDeck, GraveyardDeck playerGraveyard, CardBehaviorHandler behaviorHandler)
        {
            _playerDeck = playerDeck;
            _playerGraveyard = playerGraveyard;
            _behaviorhandler = behaviorHandler;
        }
        
        public void PlayCard(string cardName, string cardEffect)
        {
            if (!_playerDeck.ContainsCard(cardName))
            {
                throw new Exception($"The card {cardName} is not on your deck!");
            }

            if (_playerGraveyard.ContainsCard(cardName))
            {
                throw new Exception($"The card {cardName} is already on the cemetery and can't be played!");
            }
            
            _behaviorhandler.ExecuteCardBehavior(cardName, cardEffect);
            _playerGraveyard.AddCard(cardName);
        }
    }

    public abstract class AbstractDeck
    {
        protected List<string> cards;

        public bool ContainsCard(string cardName) => cards.Contains(cardName);
    }

    public class PlayerDeck : AbstractDeck
    {
        public PlayerDeck(params string[] cardNames)
        {
            cards = new List<string>(cardNames);
        }
    }

    public class GraveyardDeck : AbstractDeck
    {
        public void AddCard(string cardName) => cards.Add(cardName);
    }

    public class CardBehaviorHandler
    {
        public void ExecuteCardBehavior(string cardName, string cardEffect)
        {
            Console.WriteLine($"The {cardName} will activate the effect: {cardEffect}");
        }
    }
}