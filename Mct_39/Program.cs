using System;
using DataStructures;

namespace Mct_39
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(HasDublicates(new [] { 2, 3, 4 }));
            Console.WriteLine(HasDublicates(new[] { 2, 4, 4 }));
            Console.WriteLine(HasDublicates(new[] { 2 }));
            Console.WriteLine(HasDublicates(new int[0]));
            //Console.WriteLine(HasDublicates(null));

            Console.ReadKey();
        }

        private static bool HasDublicates(int[] array)
        {
            if (array == null) throw new ArgumentNullException();
            if (array.Length == 0) return false;

            var bsd = new Bsd<int>();

            for (var i = 1; i < array.Length; i++)
            {
                if (!bsd.Add(array[i])) return true;
            }

            return false;
        }
    }
}