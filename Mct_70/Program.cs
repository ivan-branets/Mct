using System;

namespace Mct_70
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(GetRevercedBits(1)); //result 2147483648 10000000000000000000000000000000
            Console.WriteLine(GetRevercedBits(2147483648)); //result 1 00000000000000000000000000000001
            
            Console.WriteLine(GetRevercedBits(2)); //result 1073741824 01000000000000000000000000000000
            Console.WriteLine(GetRevercedBits(1073741824)); //result 2 00000000000000000000000000000010

            Console.WriteLine(GetRevercedBits(6)); //result 1610612736 01100000000000000000000000000000
            Console.WriteLine(GetRevercedBits(1610612736)); //result 6 00000000000000000000000000000110

            Console.WriteLine(GetRevercedBits(545550534)); //result 1661870340 01100011000011100010000100000100
            Console.WriteLine(GetRevercedBits(1661870340)); //result 545550534 00100000100001000111000011000110

            Console.WriteLine(GetRevercedBits(2684452869)); //result 2684452869 10100000000000011000000000000101
            Console.WriteLine(GetRevercedBits(0));

            Console.ReadKey();
        }

        static uint GetRevercedBits(uint number)
        {
            uint rightBitMask = 0x1;
            uint leftBitMask = 0x80000000;

            const uint length = 8 * sizeof (uint);

            for (var i = 0; i < length / 2; i++)
            {
                var rightBit = rightBitMask & number;
                var leftBit = leftBitMask & number;

                if ((rightBit == 0x0) ^ (leftBit == 0x0))
                {
                    if (rightBit == 0x0)
                    {
                        number |= rightBitMask;
                        number &= ~leftBitMask;
                    }
                    else
                    {
                        number &= ~rightBitMask;
                        number |= leftBitMask;                        
                    }
                }

                rightBitMask <<= 1;
                leftBitMask >>= 1;
            }

            return number;
        }
    }
}
