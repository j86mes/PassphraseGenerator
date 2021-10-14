namespace PassphraseUtility.WordList
{
    public interface IWordListProvider
    {
        /// <summary>
        /// Retrieve a specific word form the wordlist
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string WordForKey(string index);

        /// <summary>
        /// number of digits in the indexes.
        /// "1111 apple" would have an index length of 4,
        /// "111111 apple" would have an index length of 6
        /// </summary>
        /// <returns></returns>
        public short IndexLength();

        /// <summary>
        /// the size of the dice to use per index digit (the number base).
        /// if your indexes range from 1111-6666, your dice size would be 6
        /// if your indexes ranged from 111-888 your dice size would be 8
        /// </summary>
        /// <returns></returns>
        public short IndexDiceSize();
    }
}
