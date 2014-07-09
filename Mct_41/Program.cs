using System;

namespace Mct_41
{
    class Program
    {
        static void Main()
        {
            PutLong(1208);
            Console.WriteLine();

            PutLong(-20);
            Console.WriteLine();

            PutLong(0);
            Console.WriteLine();

            Console.ReadKey();
        }

        static void PutLong(long n)
        {
            var valuable = false;

            if (n < 0)
            {
                PutChar('-');
                n = -n;
            }

            if (n == 0)
            {
                PutChar('0');
                return;
            }

            for (var i = 1000000000000000000; i != 0; i /= 10)
            {
                var digit = n / i;
                if (digit == 0 && !valuable) continue;

                PutChar(digit.ToString()[0]);
                
                n %= i;
                valuable = true;
            }
        }

        static void PutChar(char ch)
        {
            Console.Write(ch);
        }
    }
}
