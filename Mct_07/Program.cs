using System;

namespace Mct_07
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(GetRevercedStr("123 45 6"));
            //Console.WriteLine(GetRevercedStr(" 123 45  6  "));
            //Console.WriteLine(GetRevercedStr(""));
            //Console.WriteLine(GetRevercedStr("123"));
            //Console.WriteLine(GetRevercedStr("  "));
            Console.ReadKey();
        }

        private static string GetRevercedStr(string str)
        {
            if (str == null) throw new ArgumentNullException();

            var startIndex = 0;
            var endIndex = str.Length;

            var result = new char[str.Length];

            for (var i = 0; i < str.Length; i++)
            {
                if (str[--endIndex] == ' ')
                {
                    WriteWord(str, result, ref startIndex, endIndex + 1);
                    result[startIndex++] = ' ';
                }
                else if (endIndex == 0)
                {
                    WriteWord(str, result, ref startIndex, endIndex);
                }
            }

            return new string(result);
        }

        private static void WriteWord(string str, char[] result, ref int writeIndex, int wordStartIndex)
        {
            for (var j = wordStartIndex; j < str.Length && str[j] != ' '; j++)
            {
                result[writeIndex++] = str[j];
            }
        }
    }
}
