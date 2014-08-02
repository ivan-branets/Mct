using System;
using DataStructures;
using Extensions;

namespace Mct_68
{
    class Program
    {
        static void Main()
        {
            var bsts = new[]
            {
                new Bst<int> { 6, 4, 3, 5, 8, 7 },
                new Bst<int> { 6, 5, 4 },
                new Bst<int> { 6, 7, 8 },
                new Bst<int> { 6, 9, 9, 8, 7 },
                new Bst<int> { 6 },
                new Bst<int>()
            };

            foreach (var bst in bsts)
            {
                bst.EnumeratePreOrder().Log();
                bst.EnumerateInOrder().Log();
                bst.EnumeratePostOrder().Log();

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
