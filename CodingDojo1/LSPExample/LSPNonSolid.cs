using System;
using System.Collections.Generic;

namespace UnityCodingDojo.LSPExample
{
    public class NonSolidCardPlayer
    {
        public List<Card> Cards { get; set; }

        public void ExecuteCardEffects()
        {
            foreach (Card card in Cards)
            {
                if (card is EffectCard effect)
                {
                    effect.ActivateEffect();
                }
            }
        }

        public void ShowCardNames()
        {
            foreach (Card card in Cards)
            {
                Console.WriteLine(card.CardType);
            }
        }
    }

    public abstract class Card
    {
        public abstract string CardType { get; }
    }

    public class EffectCard : Card
    {
        public override string CardType => "Effect";

        public void ActivateEffect() => Console.WriteLine("Effect triggered!");
    }
    
}