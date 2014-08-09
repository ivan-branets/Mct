using System;

namespace Mct_53
{
    class Program
    {
        static void Main()
        {
            var expressions = new []
            {
                "21 + 3 * 2 - 8 / 4 * 5 - 1",
                "2 - (2 - 1)",
                "(3 - 1) * 2",
                "(3 - 1) * 2 + 1",
                "(3 - 1) * 2 + -1",
                "-(3 - 1) * 2 + -1",
                "-(3 - 1) * -2 + -1",
                "-(-3 - -1) * -2 + -1",
                "1 + -0",
                "-2"//,
                //"1 / 0",
                //"1 + + 0",
                //"1 + 0 +",
                //"1 + n",
                //"1 + 0.1",
            };

            foreach (var exp in expressions)
            {
                Console.WriteLine("{0} = {1}", exp, LexicalAnalyzer.Calculate(exp));
            }

            Console.ReadKey();
        }
    }
}