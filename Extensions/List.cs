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

            if (collection.Count == 2)
            {
                if (rand.Next(int.MaxValue) % 2 == 0)
                {
                    Swap(collection, 0, 1);
                }

                return;
            }

            var lastIndex = collection.Count - 1;

            for (var i = 0; i < collection.Count / 2; i++)
            {
                var j = rand.Next(i + 1, lastIndex);
                collection.Swap(i, j);

                j = rand.Next(0, lastIndex - i);
                collection.Swap(lastIndex - i, j);
            }
        }

        public static int BinarySearch<T>(this IList<T> sortedList, T value)
            where T : IComparable
        {
            if (sortedList == null) throw new ArgumentNullException();
            if (sortedList.Count == 0) return -1;

            var left = 0;
            var right = sortedList.Count - 1;

            while (true)
            {
                var index = left + (right - left) / 2;

                var cmp = value.CompareTo(sortedList[index]);

                switch (cmp)
                {
                    case 0:
                        return index;
                    case -1:
                        if (index == left) return -1;
                        right = index - 1;
                        break;
                    case 1:
                        if (index == right) return -1;
                        left = index + 1;
                        break;
                }
            }
        }

        public static IList<T> QuickSort<T>(this IList<T> list)
            where T : IComparable
        {
            if (list == null) throw new ArgumentNullException();
            return QuickSort(list, 0, list.Count - 1);
        }

        private static IList<T> QuickSort<T>(IList<T> list, int start, int end)
            where T : IComparable
        {
            if (end <= start) return list;

            var j = QuickSortPartition(list, start, end);

            QuickSort(list, start, j - 1);
            QuickSort(list, j + 1, end);

            return list;
        }

        private static int QuickSortPartition<T>(IList<T> list, int start, int end)
            where T : IComparable
        {
            var i = start;
            var j = end + 1;

            while (true)
            {
                while (list[++i].CompareTo(list[start]) < 0)
                {
                    if (i == end) break;
                }

                while (list[--j].CompareTo(list[start]) > 0)
                {
                    if (j == start) break;
                }

                if (i >= j) break;

                list.Swap(i, j);
            }

            list.Swap(start, j);

            return j;
        }
    }
}
