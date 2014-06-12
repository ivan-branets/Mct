using System;

namespace Mct_10
{
    class Program
    {
        static void Main()
        {
            var x = 0;
            //var x = 1;
            int y;
            var a = 10;
            var b = 20;

            IfLogical(x, out y, a, b);
            Console.WriteLine(y);

            IfArithmetic(x, out y, a, b);
            Console.WriteLine(y);

            IfDataStructure(x, out y, a, b);
            Console.WriteLine(y);

            Console.ReadKey();
        }

        private static void IfLogical(int x, out int y, int a, int b)
        {
            CheckX(x);
            y = x == 0 ? a : b;
        }

        private static void IfArithmetic(int x, out int y, int a, int b)
        {
            CheckX(x);
            y = a * (1 - x) + b * x;
        }

        private static void IfDataStructure(int x, out int y, int a, int b)
        {
            CheckX(x);

            var array = new [] { a, b };
            y = array[x];
        }

        private static void CheckX(int x)
        {
            if (x < 0 || x > 1) throw new ArgumentException("x = 0 or 1");
        }
    }
}
