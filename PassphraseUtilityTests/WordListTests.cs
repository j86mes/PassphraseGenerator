using NUnit.Framework;
using PassphraseUtility.WordList;

namespace PassphraseUtilityTests
{
    public class WordListTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShortWordListTest()
        {
            var wordList = new ShortWordListProvider();

            string testIndex = "1462";
            string expectedWord = "cache";

            Assert.IsTrue(expectedWord.Equals(wordList.WordForKey(testIndex)));
        }

        [Test]
        public void MemorableWordListTest()
        {
            var wordList = new MemorableWordListProvider();

            string testIndex = "1462";
            string expectedWord = "blender";

            Assert.IsTrue(expectedWord.Equals(wordList.WordForKey(testIndex)));
        }

        [Test]
        public void LongWordListTest()
        {
            var wordList = new LongWordListProvider ();

            string testIndex = "14623";
            string expectedWord = "capsize";

            Assert.IsTrue(expectedWord.Equals(wordList.WordForKey(testIndex)));
        }
    }
}
