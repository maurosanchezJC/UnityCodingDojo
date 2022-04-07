using System;
using System.Collections.Generic;

namespace UnityCodingDojo.LSPExample
{
    public class SolidCardPlayer
    {
        public void ExecuteCardEffects(List<IEffectCard> cards)
        {
            foreach (IEffectCard card in cards)
            {
                card.ActivateEffect();
            }
        }

        public void ShowCardNames(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card.CardType);
            }
        }
    }

    public abstract class SolidCard
    {
        public abstract string CardType { get; }
    }

    public interface IEffectCard
    {
        void ActivateEffect();
    }

    public class SolidEffectCard : SolidCard, IEffectCard
    {
        public override string CardType => "Effect";

        public void ActivateEffect() => Console.WriteLine("Effect triggered!");
    }
    
}