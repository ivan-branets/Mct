using System;
using System.Linq;
using Extensions;

namespace Mct_59
{
    class Program
    {
        static void Main()
        {
            var arrays = new int[5][];
            arrays[0] = new[] { 2, 1, 3, 1, 4, 5, 1 };
            arrays[1] = new[] { 1, 1, 1, 1, 3, 3, 3 };
            arrays[2] = new[] { 1, 1 };
            arrays[3] = new[] { 1 };
            arrays[4] = new int[0];

            foreach (var array in arrays)
            {
                Sort(array);
                array.Log();                
            }

            //Sort(null);
            //Sort(new []{ 0 });

            Console.ReadKey();
        }

        static void Sort(int[] array)
        {
            if (array == null) throw new ArgumentNullException();

            var aux = CountNumbers(array);
            OrderNumbers(array, aux);
        }

        private static void OrderNumbers(int[] array, int[] aux)
        {
            var j = 0;
            for (var i = 0; i < aux.Length; i++)
            {
                for (var z = 0; z < aux[i]; z++)
                {
                    array[j++] = i + 1;
                }
            }
        }

        private static int[] CountNumbers(int[] array)
        {
            var aux = GetAuxArray(array);

            foreach (var a in array)
            {
                if (a < 1) throw new ArgumentOutOfRangeException("array", "Cannot contain elements less then 1");
                aux[a - 1]++;
            }

            return aux;
        }

        static int[] GetAuxArray(int[] array)
        {
            if (array.Length == 0)
            {
                return new int[0];
            }

            var n = array.Max();
            var aux = new int[n];

            return aux;
        }
    }
}
