using System;

namespace Mct_73
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("{0}\t{1}", 12, F(12));

            for (uint k = 0; k <= 16; k++)
            {
                Console.WriteLine("{0}\t{1}", k, F(k));
            }

            Console.ReadKey();
        }

        static int F(uint k)
        {
            int mostSignificantBitIndex;

            uint original = GetFirstNumberWithEquelOnes(k, out mostSignificantBitIndex);
            int originalMostSignificantBitIndex = mostSignificantBitIndex;
            uint n = original;
            int steps = 1;

            while (n != k)
            {
                if (originalMostSignificantBitIndex == mostSignificantBitIndex)
                {
                    mostSignificantBitIndex++;
                    continue;
                }

                n = original;

                var mask = ~((uint)1 << (originalMostSignificantBitIndex - 1));
                n &= mask;

                mask = (uint)1 << (mostSignificantBitIndex - 1);
                n |= mask;

                var next = original << (steps - 1);

                for (var i = mostSignificantBitIndex - 1; n != next && n != k; i--)
                {
                    var prev = n;

                    mask = ~((uint)1 << i - 1);
                    n &= mask;

                    if (prev == n) continue;

                    mask = (uint)1 << i;
                    n |= mask;

                    steps++;                    
                }

                mostSignificantBitIndex++;
            }

            return steps;
        }

        static uint GetFirstNumberWithEquelOnes(uint k, out int mostSignificantBitIndex)
        {
            uint firstNumber = 0;
            mostSignificantBitIndex = 0;

            for (uint i = k; i > 0; i >>= 1)
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
