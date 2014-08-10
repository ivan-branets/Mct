using System.Collections;
using System.Collections.Generic;

namespace Mct_73
{
    public class SequenceWithEqualOnes : IEnumerable<uint>
    {
        private uint FirstNumber { get; set; }

        public SequenceWithEqualOnes(uint number)
        {
            FirstNumber = GetFirstNumberWithEquelOnes(number);
        }

        public IEnumerator<uint> GetEnumerator()
        {
            if (FirstNumber == 0)
            {
                yield return 0;
            }
            else
            {
                var curr = FirstNumber;
                yield return curr;

                while (true)
                {
                    var index = GetFirstZeroAfterOneIndex(curr);

                    curr = ShiftBitLeft(curr, index - 1);

                    var moveBackIndex = index - 2;
                    curr = MoveBack(curr, moveBackIndex);                        

                    yield return curr;
                }                
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private static int GetFirstZeroAfterOneIndex(uint number)
        {
            var index = 1;

            const int maskOne = 1;
            const int maskZero = 2;

            //find 01
            while (!((number & maskOne) == 1 && (number & maskZero) == 0))
            {
                number >>= 1;
                index++;
            }

            return index;
        }

        private static uint GetFirstNumberWithEquelOnes(uint number)
        {
            uint firstNumber = 0;

            for (uint i = number; i > 0; i >>= 1)
            {
                if ((i & 1) == 1)
                {
                    firstNumber <<= 1;
                    firstNumber++;
                }
            }

            return firstNumber;
        }

        private static uint MoveBack(uint number, int index)
        {
            var shiftSize = GetFirstOneIndex(number);

            for (var i = shiftSize; i <= index; i++)
            {
                number = ShiftBitRight(number, i, shiftSize);
            }

            return number;
        }

        private static int GetFirstOneIndex(uint number)
        {
            var index = 0;

            while ((number & 1) == 0)
            {
                number >>= 1;
                index++;
            }

            return index;
        }

        private static uint ShiftBitRight(uint number, int bitIndex, int count)
        {
            var mask = ~((uint)1 << bitIndex);
            number &= mask;

            mask = (uint)1 << bitIndex - count;
            number |= mask;

            return number;
        }

        private static uint ShiftBitLeft(uint number, int bitIndex, int count = 1)
        {
            var mask = ~((uint)1 << bitIndex);
            number &= mask;

            mask = (uint)1 << bitIndex + count;
            number |= mask;

            return number;
        }
    }
}