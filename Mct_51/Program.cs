using System;
using DataStructures;

namespace Mct_51
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
                new Bst<int> { 6, 9, 9, 8, 7, 7, 6 },
                new Bst<int> { 6 },
                new Bst<int>()
            };

            foreach (var bst in bsts)
            {
                Console.WriteLine(bst.Depth());
            }

            Console.ReadKey();
        }
    }
}
