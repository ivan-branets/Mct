using System;

namespace Mct_61
{
    class Program
    {
        static void Main()
        {
            var sum = Sum(new[] { int.MaxValue, 1, int.MinValue, -1, 2 });
            Console.WriteLine(sum);

            sum = Sum(new[] { int.MaxValue, 1, int.MinValue, -1 });
            Console.WriteLine(sum);

            sum = Sum(new int[0]);
            Console.WriteLine(sum);

            Console.ReadKey();
        }

        static int Sum(int[] array)
        {
            var result = 0;
            Array.Sort(array);

            for (var i = 0; i < array.Length / 2; i++)
            {
                result += array[i] + array[array.Length - i - 1];
            }

            if (array.Length % 2 != 0)
            {
                result += array[array.Length / 2];
            }

            return result;
        }
    }
}
