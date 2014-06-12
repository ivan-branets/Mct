using System;

namespace Mct_06
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(IsPowOf2(128));
            Console.WriteLine(IsPowOf2(129));
            Console.WriteLine(IsPowOf2(64));
            Console.WriteLine(IsPowOf2(1));
            Console.WriteLine(IsPowOf2(0));
            Console.ReadKey();
        }

        private static bool IsPowOf2(int n)
        {
            if (n < 0) throw new ArgumentException("Cannot be negative");

            var log = Math.Log(n, 2);
            return Math.Truncate(log) == log;
        }
    }
}
