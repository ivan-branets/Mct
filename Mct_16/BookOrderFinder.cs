using System.Collections.Generic;

namespace Mct_16
{
    public static class BookOrderFinder
    {
        public enum OrderType
        {
            NameAndAuthor,
            AuthorAndName
        }

        public static OrderType GetBooksOrder(IEnumerable<Book> books)
        {
            var enumerator = books.GetEnumerator();
            enumerator.MoveNext();

            var prev = enumerator.Current;
            enumerator.MoveNext();

            while (enumerator.MoveNext())
            {
                var curr = enumerator.Current;

                if (prev.Name.CompareTo(curr.Name) > 0)
                {
                    return OrderType.AuthorAndName;
                }

                if (prev.Author.CompareTo(curr.Author) > 0)
                {
                    return OrderType.NameAndAuthor;
                }

                prev = curr;
            }

            return OrderType.NameAndAuthor;
        }
    }
}
