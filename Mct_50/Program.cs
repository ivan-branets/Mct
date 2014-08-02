using System;
using DataStructures.Lists;
using Extensions;

namespace Mct_50
{
    class Program
    {
        static void Main()
        {
            var list = new DoublyLinkedList<int> { 1, 2, 3, 4, 5 };

            list.Remove(3);
            list.Log();

            list.Remove(2);
            list.Log();

            list.Remove(4);
            list.Log();

            list.Remove(5);
            list.Log();

            list.Remove(1);
            list.Log();

            Console.ReadKey();
        }
    }
}
