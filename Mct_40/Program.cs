using System;
using System.Linq;

namespace Mct_40
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(ToUpper("asdFe dsf 23 d"));
            Console.ReadKey();
        }

        static string ToUpper(string str)
        {
            return new string(str.Select(ToUpper).ToArray());
        }

        static char ToUpper(char ch)
        {
            const ushort diff = 32;
            if (ch >= 'a' && ch <= 'z')
            {

                return (char)(ch & ~diff);
            }

            return ch;
        }
    }
}
