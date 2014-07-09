using System;
using DataStructures.Lists;
using Extensions;

namespace Mct_45
{
    class Program
    {
        static void Main()
        {
            var list = new LinkedList<int> {1, 2, 3, 4, 5};
            list.Log();

            list.Reverse();
            list.Log();

            Console.ReadKey();
        }
    }
}
