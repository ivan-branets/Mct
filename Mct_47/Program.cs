using System;

namespace Mct_47
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Multiply7(5));
            Console.WriteLine(Multiply7(2));
            Console.WriteLine(Multiply7(1));
            Console.WriteLine(Multiply7(0));
            Console.WriteLine(Multiply7(-3));

            Console.ReadKey();
        }

        private static int Multiply7(int number)
        {
            return (number << 3) - number;
        }
    }
}