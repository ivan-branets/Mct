using System;
using System.Text;
using DataStructures;

namespace Mct_52
{
    class Program
    {
        static void Main()
        {
            const string str1 = "abcd cd";
            const string str2 = "bc.";

            Console.WriteLine(Substract(str1, str2));
            Console.WriteLine(Substract(str2, str1));
            Console.WriteLine(Substract(str1, str1));

            Console.ReadKey();
        }

        static string Substract(string from, string value)
        {
            var bsd = new Bsd<char>();
            foreach (var ch in value)
            {
                bsd.Add(ch);
            }

            var builder = new StringBuilder();

            foreach (var ch in from)
            {
                if (!bsd.Contains(ch))
                {
                    builder.Append(ch);
                }
            }

            return builder.ToString();
        }
    }
}
