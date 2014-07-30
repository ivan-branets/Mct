using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class Enumerable
    {
        public static IEnumerable<T> Log<T>(this IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException();

            var count = collection.Count();

            if (count > 0)
            {
                for (var i = 0; i < count - 1; i++)
                {
                    Console.Write("{0} ", collection.ElementAt(i));
                }

                Console.WriteLine(collection.ElementAt(count - 1));
            }

            return collection;
        }
    }
}
