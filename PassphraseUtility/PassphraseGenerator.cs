using System.Collections.Generic;
using System.Text;
using PassphraseUtility.WordList;
using PassphraseUtility.PassphraseDice;

namespace PassphraseUtility
{
    public class PassphraseGenerator
    {

        IWordListProvider _wordListProvider;

        /// <summary>
        /// Default PassphraseGenerator will use the LongWordListProvider
        /// </summary>
        public PassphraseGenerator()
        {
            _wordListProvider = new LongWordListProvider();
        }

        public PassphraseGenerator(IWordListProvider wordListProvider)
        {
            _wordListProvider = wordListProvider;
        }

        public string GetNewPassphrase(int numberOfWords, string separator)
        {
            var dice = new Dice((short)_wordListProvider.IndexDiceSize());

            var words = new List<string>();

            for (int currentWordIndex = 0 ; currentWordIndex < numberOfWords; currentWordIndex++)
            {
                var currentKey = new StringBuilder();

                for (int keyCharacter = 0; keyCharacter < _wordListProvider.IndexLength(); keyCharacter++)
                {
                    currentKey.Append(dice.Roll());
                }

                words.Add(currentKey.ToString());
            }

            for (int currentWordIndex = 0; currentWordIndex < words.Count; currentWordIndex++)
            {
                words[currentWordIndex] = _wordListProvider.WordForKey(words[currentWordIndex]);
            }

            return string.Join(separator, words);
        }
    }
}
