using System;

namespace Mct_42
{
    class Program
    {
        static void Main()
        {
            const int maxDegry = 10;
            for (ulong i = 1; i <= 2 << (maxDegry - 1); i++)
            {
                if (IsPowOf2(i)) Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        private static bool IsPowOf2(ulong n)
        {
            return ((ulong)(2) << sizeof (ulong) * (8 - 1)) % n == 0;
        }
    }
}
