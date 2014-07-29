using System;
using DataStructures.Lists;
using Extensions;

namespace Mct_67
{
    class Program
    {
        static void Main()
        {
            PrintReversed(new LinkedList<int> { 1, 2, 3, 4 });
            PrintReversed(new LinkedList<int> { 1 });
            PrintReversed(new LinkedList<int> { });

            //PrintReversed(null);

            Console.ReadKey();
        }

        static void PrintReversed(LinkedList<int> list)
        {
            if (list == null) throw new ArgumentNullException();

            list.Reverse();
            list.Log();
            list.Reverse();
        }
    }
}
