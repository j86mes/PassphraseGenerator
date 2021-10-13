using System.Linq;
using NUnit.Framework;
using PassphraseUtility;
using PassphraseUtility.WordList;

namespace PassphraseUtilityTests
{
    public class PassphraseGeneratorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShortWordListPassphraseTest()
        {
            var ppGenerator = new PassphraseGenerator(new ShortWordListProvider());

            Assert.IsNotNull(ppGenerator.GetNewPassphrase(5, " "));
        }

        [Test]
        public void MemorableWordListPassphraseTest()
        {
            var ppGenerator = new PassphraseGenerator(new MemorableWordListProvider());

            Assert.IsNotNull(ppGenerator.GetNewPassphrase(5, " "));
        }

        [Test]
        public void LongWordListPassphraseTest()
        {
            var ppGenerator = new PassphraseGenerator(new LongWordListProvider());

            Assert.IsNotNull(ppGenerator.GetNewPassphrase(5, " "));
        }

        [Test]
        public void PassphraseSeparatorTest()
        {
            var ppGenerator = new PassphraseGenerator(new LongWordListProvider());

            int words = 5;
            string separator = "_";
            string passphrase = ppGenerator.GetNewPassphrase(words, separator);

            int numberOfSeparators = passphrase.Count(c => c == '_');

            Assert.AreEqual(numberOfSeparators, words-1);
        }
    }
}
