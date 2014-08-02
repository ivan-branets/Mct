using System;
using Extensions;

namespace Mct_65
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Intersect(new[] { 1, 2, 3 }, new[] { 4, 5, 2 }));
            Console.WriteLine(Intersect(new[] { 1, 2, 3 }, new[] { 2, 5, 4 }));
            Console.WriteLine(Intersect(new[] { 1, 2, 3 }, new[] { 5, 2, 4 }));
            Console.WriteLine(Intersect(new[] { 1, 2, 3 }, new[] { 5, 2, 4, 2 }));
            Console.WriteLine(Intersect(new[] { 1, 2, 3 }, new[] { 2, 1 }));
            Console.WriteLine(Intersect(new[] { 1, 2, 3 }, new[] { 3 }));
            Console.WriteLine(Intersect(new[] { 1, 2, 3 }, new[] { -1 }));
            Console.WriteLine(Intersect(new[] { 1, 2, 3 }, new int[0]));

            //Console.WriteLine(Intersect(new[] { 1, 2, 3 }, (int[]) null));
            //Console.WriteLine(Intersect((int[]) null, (int[]) null));

            Console.ReadKey();
        }

        static bool Intersect(int[] fixedList, int[] floatList)
        {
            if (fixedList == null || floatList == null) throw new ArgumentNullException();

            floatList.QuickSort();

            foreach (var f in fixedList)
            {
                if (floatList.BinarySearch(f) > -1) return true;
            }

            return false;
        }
    }
}
