using System;
using DataStructures.Lists;

namespace Mct_69
{
    class Program
    {
        static void Main()
        {
            var list = new LinkedList<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine(list.GetMiddle());

            list = new LinkedList<int> { 1, 2, 3, 4 };
            Console.WriteLine(list.GetMiddle());

            list = new LinkedList<int> { 1, 2 };
            Console.WriteLine(list.GetMiddle());

            list = new LinkedList<int> { 1 };
            Console.WriteLine(list.GetMiddle());

            //list = new LinkedList<int> { };
            //Console.WriteLine(list.GetMiddle());

            Console.ReadKey();
        }
    }
}
