using System;

namespace Mct_73
{
    class Program
    {
        static void Main()
        {
            for (uint k = 0; k <= 16; k++)
            {
                Console.WriteLine("f({0}) = {1}", k, F(k));
            }

            Console.WriteLine("f({0}) = {1}", 1024, F(1024));
            Console.WriteLine("f({0}) = {1}", uint.MaxValue, F(uint.MaxValue));

            Console.ReadKey();
        }

        private static int F(uint k)
        {
            var enumerator = new SequenceWithEqualOnes(k).GetEnumerator();
            var index = 1;

            while (enumerator.MoveNext() && enumerator.Current != k)
            {
                index++;
            }

            return index;
        }
    }
}