using System;
using DataStructures.Lists;
using Extensions;

namespace Mct_58
{
    class Program
    {
        static void Main()
        {
            var list = new SortedList<int> { 3, 3, 1, 2, 4, 1, 5 };
            list.GetUnique().Log();

            list = new SortedList<int> { 3, 3 };
            list.GetUnique().Log();

            list = new SortedList<int> { 1 };
            list.GetUnique().Log();

            list = new SortedList<int> { };
            list.GetUnique().Log();

            Console.ReadKey();
        }
    }
}
