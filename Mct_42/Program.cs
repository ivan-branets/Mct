using System;

namespace Mct_42
{
    class Program
    {
        static void Main()
        {
            const int maxDegry = 10;
            for (ulong i = 1; i <= Math.Pow(2, maxDegry); i++)
            {
                if (IsPowOf2(i)) Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        private static bool IsPowOf2(ulong n)
        {
            const ulong maxPowOf2 = 0x8000000000000000;
            return maxPowOf2 % n == 0;
        }
    }
}
