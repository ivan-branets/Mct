using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class List
    {
        public static void Swap<T>(this IList<T> collection, int i, int j)
        {
            var tmp = collection[i];
            collection[i] = collection[j];
            collection[j] = tmp;
        }

        public static void Shuffle<T>(this IList<T> collection)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            var lastIndex = collection.Count - 1;

            for (var i = 0; i < collection.Count / 2; i++)
            {
                var j = rand.Next(i + 1, lastIndex);
                collection.Swap(i, j);

                j = rand.Next(0, lastIndex - i);
                collection.Swap(lastIndex - i, j);
            }
        }

    }
}
