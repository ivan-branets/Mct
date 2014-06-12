using System;
using DataStructures.Lists;
using Extensions;

namespace Mct_12
{
    class Program
    {
        static void Main()
        {
            var list = new SortedList<int> { 3, 1, 2, 4, 1, 5 };
            list.Log();

            Console.ReadKey();
        }
    }
}
