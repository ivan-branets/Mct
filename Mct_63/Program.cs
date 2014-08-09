using System;
using DataStructures.Lists;
using Extensions;

namespace Mct_63
{
    class Program
    {
        static void Main()
        {
            var arrays = new[]
            {
                new []{ "abc", "ab", "ac", "acc", "ab" },
                new []{ "xz", "ab", "ac", "" },
                new []{ "a", "b", "b", "a" },
                new []{ "a", "c", "a" },
                new []{ "c", "a", "b" },
                new []{ "a", "b" },
                new []{ "a" },
                new string[] { null },
                new [] { "a", null }
            };

            foreach (var strings in arrays)
            {
                string min;
                string max;

                FindMinAndMax(strings, out min, out max);

                strings.Log();

                Console.WriteLine("min: {0}", min);
                Console.WriteLine("max: {0}", max);

                Console.WriteLine();   
            }

            Console.ReadKey();
        }

        static void FindMinAndMax(string[] strings, out string min, out string max)
        {
            LinkedList<string> smallStrings;
            LinkedList<string> bigStrings;

            InitializeLists(strings, out smallStrings, out bigStrings);

            while (smallStrings.Count > 1)
            {
                smallStrings.RemoveAt(Cmp(smallStrings[0], smallStrings[1]) < 0 ? 1 : 0);
            }

            while (bigStrings.Count > 1)
            {
                bigStrings.RemoveAt(Cmp(bigStrings[0], bigStrings[1]) > 0 ? 1 : 0);
            }

            min = smallStrings.Count > 0 ? smallStrings[0] : bigStrings[0];
            max = bigStrings[0];
        }

        static void InitializeLists(string[] strings, out LinkedList<string> smallStrings, out LinkedList<string> bigStrings)
        {
            smallStrings = new LinkedList<string>();
            bigStrings = new LinkedList<string>();

            for (var i = 0; i < strings.Length - strings.Length % 2; i += 2)
            {
                if (Cmp(strings[i], strings[i + 1]) < 0)
                {
                    smallStrings.Add(strings[i]);
                    bigStrings.Add(strings[i + 1]);
                }
                else
                {
                    smallStrings.Add(strings[i + 1]);
                    bigStrings.Add(strings[i]);
                }
            }

            if (smallStrings.Count + bigStrings.Count < strings.Length)
            {
                if (Cmp(strings[strings.Length - 1], strings[0]) < 0)
                {
                    smallStrings.Insert(0, strings[strings.Length - 1]);
                }
                else
                {
                    bigStrings.Add(strings[strings.Length - 1]);
                }
            }
        }

        static int Cmp(string a, string b)
        {
            if (a == null && b == null) return 0;
            if (a == null) return -1;
            if (b == null) return 1;

            int i;
            for (i = 0; i < (a.Length < b.Length ? a.Length : b.Length); i++)
            {
                if (a[i] < b[i]) return -1;
                if (a[i] > b[i]) return 1;
            }

            if (i != b.Length) return -1;
            if (i != a.Length) return 1;

            return 0;
        }
    }
}
