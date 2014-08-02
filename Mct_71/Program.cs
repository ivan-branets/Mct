using System;

namespace Mct_71
{
    class Program
    {
        static void Main()
        {
            for (uint i = 1; i <= 1024; i*=2)
            {
                Console.WriteLine("{0}\t{1}\t{2}", i, Log2(i), (uint)Math.Log(i, 2));
            }

            Console.WriteLine();

            for (uint i = 5; i <= 15; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}", i, Log2(i), (uint)Math.Log(i, 2));
            }

            //Log2(0);

            Console.ReadKey();
        }

        static int Log2(uint number)
        {
            if (number == 0) throw new ArgumentOutOfRangeException("number", "Have to be > 0");

            var log2 = -1;

            while (number > 0)
            {
                log2++;
                number >>= 1;
            }

            return log2;
        }
    }
}
