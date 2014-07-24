using System;
using DataStructures.Lists;
using Extensions;

namespace Mct_46
{
    class Program
    {
        static void Main()
        {
            var list = new SortedList<int> { 3, 1, 2, 4, 1, 5 };

            list.Add(3);
            list.Log();

            list.Add(4);
            list.Log();

            list.Add(6);
            list.Log();

            list.Add(-1);
            list.Log();

            Console.ReadKey();
        }
    }
}
