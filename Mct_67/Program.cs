using System;
using DataStructures.Lists;
using Extensions;

namespace Mct_67
{
    class Program
    {
        static void Main()
        {
            var list = new LinkedList<int> { 1, 2, 3, 4 };
            PrintReversed(list);
            Console.ReadKey();
        }

        static void PrintReversed(LinkedList<int> list)
        {
            list.Reverse();
            list.Log();
            list.Reverse();
        }
    }
}
