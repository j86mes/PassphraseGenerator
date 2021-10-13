using System;
using System.IO;

namespace PassphraseUtility.WordList
{
    public class LongWordListProvider: EmbeddedWordListProvider, IWordListProvider
    {
        private string _resourceFileName = "PassphraseUtility.Resources.eff_large_wordlist.txt";

        public LongWordListProvider()
        {
        }

        public short IndexDiceSize()
        {
            return 6;
        }

        public short IndexLength()
        {
            return 5;
        }

        public string WordForKey(string index)
        {
            using (var stream = GetEmbeddedResourceStream(_resourceFileName))
            {
                using (var reader = new StreamReader(stream))
                {
                    while (false == reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        string wordIndex = line.Substring(0, line.IndexOf('\t'));

                        if (wordIndex == index)
                        {
                            return line.Substring(line.IndexOf('\t') + 1);
                        }
                    }

                    throw new ArgumentException($"No entry in wordlist for key", nameof(index));
                }
            }
        }
    }
}
