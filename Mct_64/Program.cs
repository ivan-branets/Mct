using System;
using Extensions;

namespace Mct_64
{
    class Program
    {
        static void Main()
        {
            var arrays = new int[6][];

            arrays[0] = new []{ 1, 1, 2, 3, 3, 4, 5, 5 };
            arrays[1] = new []{ 1, 2, 3, 3, 3, 4, 5 };
            arrays[2] = new []{ 5, 5, 4, 2, 1, 1, 0, -3 };
            arrays[3] = new []{ 1, 1 };
            arrays[4] = new []{ 1 };
            arrays[5] = new int[0];

            for (var i = 0; i < arrays.Length; i++)
            {
                RemoveDuplicates(ref arrays[i]);
                arrays[i].Log();
            }

            Console.ReadKey();
        }

        static void RemoveDuplicates(ref int[] array)
        {
            if (array.Length == 0) return;

            var lastUniqueIndex = 0;

            for (var i = 1; i < array.Length; i++)
            {
                if (array[i] != array[lastUniqueIndex])
                {
                    array[++lastUniqueIndex] = array[i];
                }
            }

            var newLength = lastUniqueIndex + 1;
            var tmp = new int[newLength];

            Array.Copy(array, tmp, newLength);
            array = tmp;
        }
    }
}
