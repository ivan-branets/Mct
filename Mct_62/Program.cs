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
                Thread.Sleep(1);
            }

            Console.ReadKey();
        }

        static int[] GetRandomPermutation(int[] array)
        {
            var result = array.Clone() as int[];
            result.Shuffle();

            return result;
        }
    }
}
