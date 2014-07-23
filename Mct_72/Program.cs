using System;

namespace Mct_72
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(InvertMostSignificantBit(0x1)); //0001
            Console.WriteLine(InvertMostSignificantBit(0x3)); //0011
            Console.WriteLine(InvertMostSignificantBit(0x5)); //0101
            Console.WriteLine(InvertMostSignificantBit(0xf)); //1111
            Console.WriteLine(InvertMostSignificantBit(0x82)); //10000010

            Console.ReadKey();
        }

        static uint InvertMostSignificantBit(uint number)
        {
            const uint maxPowOf2 = 0x80000000;
            var mask = maxPowOf2;

            while ((mask | number) != number)
            {
                mask >>= 1;
            }

            mask = ~mask;
            number &= mask;

            return number;
        }
    }
}
