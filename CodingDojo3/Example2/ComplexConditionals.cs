using System;

namespace CodingDojo3.Example3
{
    public class ComplexConditionals
    {
        
        public class Wizard
        {
            public string element;
            public int life;
            public int mana;
            public int iceAttackCost;
        }

        public void WizardAttackWithIce()
        {
            Wizard theWizard = new Wizard()
            {
                element = "ice",
                life = 10,
                mana = 30,
                iceAttackCost = 100
            };

            if (theWizard.element == "ice" && theWizard.life > 0 && theWizard.iceAttackCost < theWizard.mana)
            {
                Console.WriteLine("The wizard is attacking!");
                theWizard.mana -= theWizard.iceAttackCost;
            }
        }
    }
}