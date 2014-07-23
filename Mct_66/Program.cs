using System;
using DataStructures.Lists;

namespace Mct_66
{
    class Program
    {
        static void Main()
        {
            var list = new LinkedList<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine(list.HasLoop());

            list.AddLoop(2);
            Console.WriteLine(list.HasLoop());

            Console.ReadKey();
        }
    }
}
