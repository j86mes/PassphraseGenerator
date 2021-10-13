using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PassphraseUtility.PassphraseDice;

namespace PassphraseUtilityTests
{
    public class DiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ZeroIndexedTest()
        {
            var dice = new Dice(6, true);

            List<short> diceRolls = new List<short>();

            for (int i=0; i < 100; i++)
            {
                diceRolls.Add(dice.Roll());
            }

            Assert.IsNotEmpty(diceRolls.Where(x => x == 0));

            Assert.IsEmpty(diceRolls.Where(x => x > 5));
        }

        [Test]
        public void NonZeroIndexedTest()
        {
            var dice = new Dice(6, false);

            List<short> diceRolls = new List<short>();

            for (int i = 0; i < 100; i++)
            {
                diceRolls.Add(dice.Roll());
            }

            Assert.IsEmpty(diceRolls.Where(x => x == 0));

            Assert.IsNotEmpty(diceRolls.Where(x => x == 6));

            Assert.IsEmpty(diceRolls.Where(x => x > 6));
        }
    }
}
