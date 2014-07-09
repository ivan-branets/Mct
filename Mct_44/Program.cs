using System;

namespace Mct_44
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine(CountOnes(0));
            //Console.WriteLine(CountOnes(1));
            //Console.WriteLine(CountOnes(2));
            //Console.WriteLine(CountOnes(5));
            //Console.WriteLine(CountOnes(20)); //00010100
            Console.WriteLine(CountOnes(2344353)); //00000000 00100011 11000101 10100001
            Console.WriteLine(CountOnes(uint.MaxValue));

            Console.ReadKey();
        }

        static int CountOnes(uint n)
        {
            const int byteCount = sizeof(uint);
            var sum = 0;

            for (var i = 0; i < byteCount * 2; i++)
            {
                sum += GetOnesIn4Bits(n & 15);
                n = n >> 4;
            }

            return sum;
        }

        static int GetOnesIn4Bits(uint n)
        {
            const int lenght = 16;
            var fbc = new int[lenght];
            fbc[0] = 0;  //0000
            fbc[1] = 1;  //0001
            fbc[2] = 1;  //0010
            fbc[3] = 2;  //0011
            fbc[4] = 1;  //0100
            fbc[5] = 2;  //0101
            fbc[6] = 2;  //0110
            fbc[7] = 3;  //0111
            fbc[8] = 1;  //1000
            fbc[9] = 2;  //1001
            fbc[10] = 2; //1010
            fbc[11] = 3; //1011
            fbc[12] = 2; //1100
            fbc[13] = 3; //1101
            fbc[14] = 3; //1110
            fbc[15] = 4; //1111

            return fbc[n];
        }
    }
}
