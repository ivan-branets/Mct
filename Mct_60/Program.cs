using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;

namespace Mct_60
{
    class Program
    {
        static void Main()
        {
            var arrays = new int[5][];

            arrays[0] = new[] { 2, 3, 2, 1, 1, 4, 3, 5 };
            arrays[1] = new[] { 2, 2, 2, 1, 1, 4, 5, 5 };
            arrays[2] = new[] { 2, 2 };
            arrays[3] = new[] { 2 };
            arrays[4] = new int[0];

            foreach (var a in arrays)
            {
                var array = a;

                Compress(ref array);
                array.Log();
            }

            Console.ReadKey();
        }

        static void Compress(ref int[] array)
        {
            bool[] aux;
            int compressedArraySize;

            FindUniqueElements(array, out aux, out compressedArraySize);
            FillWithUniqueElements(out array, aux, compressedArraySize);
        }

        private static void FindUniqueElements(int[] array, out bool[] aux, out int compressArraySize)
        {
            compressArraySize = 0;
            aux = GetAuxArray(array);

            foreach (var a in array)
            {
                if (!IsSeen(a, aux))
                {
                    SetSeen(a, aux);
                    compressArraySize++;
                }
            }
        }

        private static void FillWithUniqueElements(out int[] array, bool[] aux, int compressedArraySize)
        {
            array = new int[compressedArraySize];

            var j = 0;
            for (var i = 0; i < aux.Length; i++)
            {
                if (aux[i])
                {
                    array[j++] = i + 1;
                }
            }
        }

        static bool[] GetAuxArray(int[] array)
        {
            if (array.Length == 0)
            {
                return new bool[0];
            }

            var n = array.Max();
            var aux = new bool[n];

            return aux;
        }

        static bool IsSeen(int a, IList<bool> aux)
        {
            return aux[a - 1];
        }

        static void SetSeen(int a, IList<bool> aux)
        {
            aux[a - 1] = true;
        }
    }
}
