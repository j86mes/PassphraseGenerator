using System;
using System.Security.Cryptography;

namespace PassphraseUtility.PassphraseDice
{
    public class Dice
    {
        RNGCryptoServiceProvider _randomProvider = null;
        UInt16 _sides = 6;
        bool _zeroIndexed = false;

        public Dice(short sides = 6, bool zeroIndexed = false)
        {
            _randomProvider = new RNGCryptoServiceProvider();
            _sides = (UInt16)sides;
            _zeroIndexed = zeroIndexed;
        }

        public short Roll()
        {
            return (short)GetFairRollResult(this._sides, this._zeroIndexed);
        }

        public short Roll(short sides, bool zeroIndexed)
        {

            return (short)GetFairRollResult((UInt16)sides, zeroIndexed);
        }

        private UInt16 GetFairRollResult(UInt16 sides, bool zeroIndexed)
        {
            if (sides <= 0)
            {
                throw new ArgumentException("sides must be greater than 0");
            }
            var roll = new byte[2];
            UInt16 result;

            do
            {
                _randomProvider.GetBytes(roll);
                result = BitConverter.ToUInt16(roll);

            } while (isValueOutsideOfFairBoundary(result, sides));

            result = (UInt16)(result % sides);

            if (false == zeroIndexed)
            {
                result += 1;
            }
            return result;
        }

        private bool isValueOutsideOfFairBoundary(UInt16 value, UInt16 sides)
        {
            var fullSetsOfValues = UInt16.MaxValue / sides;
            return value >= sides * fullSetsOfValues;
        }
    }
}
