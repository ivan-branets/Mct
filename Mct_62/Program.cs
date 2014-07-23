using System;
using System.Threading;
using Extensions;

namespace Mct_62
{
    class Program
    {
        static void Main()
        {
            var array = new[] { 1, 2, 3, 4, 5 };

            for (var i = 0; i < 5; i++)
            {
                GetRandomPermutation(array).Log();
                EnsureNewRandom();
            }

            GetRandomPermutation(new int[0]).Log();
            GetRandomPermutation(new[] { 1 }).Log();
            GetRandomPermutation(new[] { 1, 2 }).Log();

            Console.ReadKey();
        }

        static int[] GetRandomPermutation(int[] array)
        {
            var result = (int[])array.Clone();
            result.Shuffle();

            return result;
        }

        private static void EnsureNewRandom()
        {
            Thread.Sleep(1);
        }
    }
}
