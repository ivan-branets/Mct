using System;

namespace Mct_16
{
    class Program
    {
        static void Main()
        {
            var books1 = new[] {
                new Book("1", "4"),
                new Book("2", "5"),
                new Book("3", "2")
            };

            var books2 = new[] {
                new Book("3", "1"),
                new Book("4", "2"),
                new Book("1", "2"),
            };

            Output(BookOrderFinder.GetBooksOrder(books1));
            Output(BookOrderFinder.GetBooksOrder(books2));

            Console.ReadKey();
        }

        static void Output(BookOrderFinder.OrderType orderType)
        {
            if (orderType == BookOrderFinder.OrderType.NameAndAuthor)
            {
                Console.WriteLine("Books are sorted by name. The books with the same name are sorted by author.");
            }
            else
            {
                Console.WriteLine("Books are sorted by author. The books with the same author are sorted by name.");
            }
        }
    }
}
