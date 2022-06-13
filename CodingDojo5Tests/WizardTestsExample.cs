using NUnit.Framework;
using CodingDojo5;

namespace CodingDojo5Tests
{
    [TestFixture]
    public class WizardTestsExample
    {
        private Wizard wizard = new Wizard();
        
        [SetUp]
        public void SetupWizard()
        {
            wizard = new Wizard();
            const int WIZARD_MANA = 50;
            wizard.ManaPoints = WIZARD_MANA;
        }

        [Test]
        public void CanCastMagic_CostIsLowerThanAvailable_ReturnsTrue()
        {
            const int MAGIC_COST = 30;
            
            bool canCast = wizard.CanCastMagic(MAGIC_COST);
            Assert.IsTrue(canCast, "Wizard hasn't enough mana points!");
        }
        
        
        [Test]
        public void CanCastMagic_CostIsHigherThanAvailable_ReturnsFalse()
        {
            const int MAGIC_COST = 70;

            bool canCast = wizard.CanCastMagic(MAGIC_COST);
            Assert.IsFalse(canCast, "Wizard has enough mana points!");
        }

        [TearDown]
        public void TearDownWizard()
        {
            wizard = null;
        }
    }
}