using System;

namespace CodingDojo3.Example3
{
    public class SimpleConditionals
    {
        public void WizardAttackWithIce()
        {
            Wizard theWizard = new Wizard()
            {
                element = "ice",
                life = 10,
                mana = 30,
                iceAttackCost = 100
            };

            if (theWizard.CanDoIceAttack())
            {
                theWizard.DoIceAttack();
            }
        }
        
        public class Wizard
        {
            public string element;
            public int life;
            public int mana;
            public int iceAttackCost;

            public bool CanDoIceAttack() => HasLife && IsOfIceType && CanPerformAttack(iceAttackCost);

            private bool HasLife => life > 0;
            private bool IsOfIceType => element == "ice";
            public bool CanPerformAttack(int cost) => mana > cost;
            

            public void DoIceAttack()
            {
                ConsumeMana(iceAttackCost);
                Console.WriteLine("The wizard is attacking!");
            }

            private void ConsumeMana(int amount)
            {
                mana -= amount;
            }
        }
    }
}