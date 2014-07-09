using System;
using System.Linq;
using Extensions;

namespace Mct_38
{
    class Program
    {
        static void Main()
        {
            //var array = new[] { 4, 3 };
            //var array = new[] { 4, 3, 0, 0 };
            //var array = new[] { 0, 0, 4, 3 };
            var array = new[] { 4, 3, -2, -5, 8, 4, -5 };
            //var array = new[] { 4, 3, -2, -4, 8, 4, -5 };
            //var array = new[] { -4, -2, -3, -4 };
            //int[] array = null;

            var result = GetMaxSumSubArray(array);
            result.Log();

            Console.ReadKey();
        }

        private static int[] GetMaxSumSubArray(int[] array)
        {
            if (array == null) throw new ArgumentNullException();

            var maxStart = 0;
            var maxLenght = 0;
            var maxSum = int.MinValue;

            var lenght = 0;
            var sum = 0;

            var isNew = true;

            for (var i = 0; i < array.Length; i++)
            {
                sum += array[i];
                lenght++;

                if (sum > maxSum)
                {
                    maxLenght = lenght;
                    maxSum = sum;

                    if (isNew)
                    {
                        isNew = false;
                        maxStart = i;
                    }
                }
                
                if (sum <= 0)
                {
                    sum = 0;
                    isNew = true;
                    lenght = 0;
                }
            }

            return array.Skip(maxStart).Take(maxLenght).ToArray();
        }
    }
}
