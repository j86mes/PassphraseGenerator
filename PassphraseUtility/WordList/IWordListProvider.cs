using System;
namespace PassphraseUtility.WordList
{
    public interface IWordListProvider
    {
        public string WordForKey(string index);
        public short IndexLength();
        public short IndexDiceSize();
    }
}
