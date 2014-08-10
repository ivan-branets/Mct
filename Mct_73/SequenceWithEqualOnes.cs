using System.Collections;
using System.Collections.Generic;

namespace Mct_73
{
    public class SequenceWithEqualOnes : IEnumerable<uint>
    {
        public SequenceWithEqualOnes(uint number)
        {
            CurrentNumber = GetFirstNumberWithEquelOnes(number, out _oneCount);
        }

        private uint CurrentNumber { get; set; }
        private readonly int _oneCount;

        public IEnumerator<uint> GetEnumerator()
        {
            while (CurrentNumber < uint.MaxValue)
            {
                yield return CurrentNumber;

                var newNumber = CurrentNumber;

                do
                {
                    newNumber++;
                }
                while (_oneCount != GetNumberOfOnes(newNumber));

                CurrentNumber = newNumber;                
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private static int GetNumberOfOnes(uint number)
        {
            var count = 0;

            while (number != 0)
            {
                if ((number & 1) == 1)
                {
                    count++;
                }

                number >>= 1;
            }

            return count;
        }

        private static uint GetFirstNumberWithEquelOnes(uint number, out int mostSignificantBitIndex)
        {
            uint firstNumber = 0;
            mostSignificantBitIndex = 0;

            for (uint i = number; i > 0; i >>= 1)
            {
                if ((i & 1) == 1)
                {
                    firstNumber <<= 1;
                    firstNumber++;

                    mostSignificantBitIndex++;
                }
            }

            return firstNumber;
        }
    }
}