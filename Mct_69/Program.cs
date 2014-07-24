using System;
using DataStructures.Lists;

namespace Mct_69
{
    class Program
    {
        static void Main()
        {
            var list = new LinkedList<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine(GetMiddle(list));

            list = new LinkedList<int> { 1, 2, 3, 4 };
            Console.WriteLine(GetMiddle(list));

            list = new LinkedList<int> { 1, 2 };
            Console.WriteLine(GetMiddle(list));

            list = new LinkedList<int> { 1 };
            Console.WriteLine(GetMiddle(list));

            //list = new LinkedList<int> { };
            //Console.WriteLine(GetMiddle(list));

            Console.ReadKey();
        }

        private static int GetMiddle(LinkedList<int> list)
        {
            var i = 0;
            var middle = list.Count / 2;

            foreach (var value in list)
            {
                if (i == middle)
                {
                    return value;
                }
                i++;
            }

            throw new InvalidOperationException("List doesn't contain elements");
        }
    }
}
